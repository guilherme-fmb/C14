param(
    [Parameter(Mandatory = $true)][string]$PipelineStatus,
    [Parameter(Mandatory = $true)][string]$BuildStatus,
    [Parameter(Mandatory = $true)][string]$TestStatus
)

$ErrorActionPreference = 'Stop'

function Get-EnvOrThrow([string]$name) {
    $value = [Environment]::GetEnvironmentVariable($name)
    if ([string]::IsNullOrWhiteSpace($value)) {
        throw "Required environment variable '$name' is not set."
    }
    return $value
}

# Read configuration from environment variables
$to = Get-EnvOrThrow 'NOTIFY_EMAIL'
$from = Get-EnvOrThrow 'EMAIL_FROM'
$smtpServer = Get-EnvOrThrow 'SMTP_SERVER'
$smtpPort = [int](Get-EnvOrThrow 'SMTP_PORT')
$smtpUser = Get-EnvOrThrow 'SMTP_USERNAME'
$smtpPass = Get-EnvOrThrow 'SMTP_PASSWORD'
$smtpUseSslRaw = [Environment]::GetEnvironmentVariable('SMTP_USE_SSL')
$smtpUseSsl = $true
if (-not [string]::IsNullOrWhiteSpace($smtpUseSslRaw)) {
    $smtpUseSsl = [System.Convert]::ToBoolean($smtpUseSslRaw)
}

$repo = $env:GITHUB_REPOSITORY
$runId = $env:GITHUB_RUN_ID
$runNumber = $env:GITHUB_RUN_NUMBER
$workflow = $env:GITHUB_WORKFLOW
$branch = $env:GITHUB_REF
$commit = $env:GITHUB_SHA
$actor = $env:GITHUB_ACTOR
$runUrl = "https://github.com/$repo/actions/runs/$runId"

$subject = "[$repo] CI $workflow - Build:$BuildStatus, Tests:$TestStatus, Pipeline:$PipelineStatus (Run #$runNumber)"

$body = @"
Repository: $repo
Workflow:   $workflow
Run:        #$runNumber ($runUrl)
Branch:     $branch
Commit:     $commit
Actor:      $actor

Results:
  - Build:       $BuildStatus
  - Tests:       $TestStatus
  - Pipeline:    $PipelineStatus

Timestamp (UTC): $(Get-Date)
"@

# Prefer Send-MailKitMessage if available (PowerShell module MailKit). Fallback to System.Net.Mail.
try {
    if (Get-Command -Name Send-MailKitMessage -ErrorAction SilentlyContinue) {
        Send-MailKitMessage -To $to -From $from -SmtpServer $smtpServer -Port $smtpPort -UseSsl:$smtpUseSsl -Subject $subject -TextBody $body -Credential (New-Object System.Management.Automation.PSCredential($smtpUser,(ConvertTo-SecureString $smtpPass -AsPlainText -Force)))
    } else {
        $secure = ConvertTo-SecureString $smtpPass -AsPlainText -Force
        $cred = New-Object System.Management.Automation.PSCredential($smtpUser, $secure)
        Send-MailMessage -To $to -From $from -SmtpServer $smtpServer -Port $smtpPort -UseSsl:$smtpUseSsl -Subject $subject -Body $body -Credential $cred
    }
    Write-Host "Email notification sent to $to"
} catch {
    Write-Warning "Failed to send email: $($_.Exception.Message)"
    exit 1
}
