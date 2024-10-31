# Configurazione
$backupPath = "C:\Backups\DB\WarehouseAcceptance"
$databaseName = "WarehouseDB"
$serverInstance = ".\SQLEXPRESS"  # Modifica se usi un'istanza diversa
$retentionDays = 30

# Crea cartella backup se non esiste
function EnsureBackupPath {
    if (-not (Test-Path $backupPath)) {
        New-Item -ItemType Directory -Path $backupPath
        Write-Host "Creata directory backup: $backupPath"
    }
}

# Esegui backup
function PerformBackup {
    $timestamp = Get-Date -Format "yyyyMMdd_HHmmss"
    $backupFile = Join-Path $backupPath "WarehouseAcceptance_$timestamp.bak"
    
    try {
        # Rimossa l'opzione COMPRESSION
        $query = "BACKUP DATABASE [$databaseName] TO DISK = N'$backupFile' WITH FORMAT"
        Invoke-Sqlcmd -ServerInstance $serverInstance -Query $query
        Write-Host "Backup completato: $backupFile"
    }
    catch {
        Write-Error "Errore durante il backup: $_"
        exit 1
    }
}
# Pulisci backup vecchi
function CleanOldBackups {
    $limit = (Get-Date).AddDays(-$retentionDays)
    Get-ChildItem -Path $backupPath -Filter "*.bak" | 
        Where-Object { $_.CreationTime -lt $limit } |
        ForEach-Object {
            Remove-Item $_.FullName -Force
            Write-Host "Rimosso backup vecchio: $($_.Name)"
        }
}

# Esegui le operazioni
EnsureBackupPath
PerformBackup
CleanOldBackups