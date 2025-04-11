@echo off
echo 🧹 Nettoyage du projet .NET...

REM Supprimer la base SQLite
if exist Maintenance.db (
    del Maintenance.db
    echo 🗑️ Base SQLite supprimée.
)

REM Supprimer les bin et obj
rmdir /s /q bin
rmdir /s /q obj
echo 🗑️ Dossiers bin et obj supprimés.

REM Supprimer les migrations
rmdir /s /q Migrations
echo 🗑️ Anciennes migrations supprimées.

REM Recréer la migration Initial
dotnet ef migrations add Initial

REM Mise à jour de la base
dotnet ef database update

REM Lancer l’API
echo 🚀 Lancement de l'API...
dotnet run
