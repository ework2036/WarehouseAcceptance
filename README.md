# WarehouseAcceptance

Applicazione per la gestione del controllo e l'accettazione dei materiali in ingresso al magazzino.

## Funzionalità Principali
- Acquisizione e gestione DDT
- Controllo materiali e quantità
- Verifica codifiche componenti
- Gestione non conformità
- Tracking performance qualità

## Struttura del Progetto
- **Core**: Logica di business
- **Data**: Accesso ai dati
- **Web**: Interfaccia utente

## Tecnologie Utilizzate
- .NET Framework 4.8
- SQL Server Express
- Entity Framework 6
- WebForms + Bootstrap 5
- Unity per Dependency Injection

## Versioni
- v1.0.0: Sistema Base con gestione fornitori
  - CRUD Fornitori completato
  - Database operativo
  - UI Bootstrap implementata

## Branch
- main: codice stabile e testato
- feature/template-management: sviluppo gestione template

## Backup Database
- Backup automatico giornaliero alle 23:00
- Location: C:\Backups\DB\WarehouseAcceptance
- Retention: 30 giorni
- Task Scheduler: WarehouseAcceptance_DB_Backup

## Sviluppo
1. Creare branch per nuove feature: `feature/nome-feature`
2. Tag per versioni: `vX.Y.Z`
3. Commit messages in italiano