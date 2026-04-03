# GSB – Gestion des visites

Application desktop **Windows Forms (.NET)** pour la gestion des visites médicales du laboratoire Galaxy-Swiss Bourdin.

## Fonctionnalités

- Connexion utilisateur via base MySQL
- Consultation des visites
- Ajout d’un rendez-vous
- Modification / suppression d’un rendez-vous
- Enregistrement du bilan d’une visite (dont échantillons)
- Impression / aperçu des rendez-vous sur une période

## Architecture du projet

La solution `Gsb2026.slnx` contient 3 projets :

- `Interface` : interface Windows Forms (`net10.0-windows`)
- `Donnee` : accès aux données MySQL (`MySqlConnector`)
- `Metier` : classes métier (Visite, Praticien, Medicament, etc.)

## Prérequis

- .NET SDK 10
- Windows (pour exécuter l’interface WinForms)
- Serveur MySQL accessible
- Base de données `gsb`

## Configuration base de données

La connexion est construite dans `Donnee/Passerelle.cs` avec :

- Hôte : `localhost`
- Base : `gsb`
- Identifiants : saisis à l’écran de connexion

La couche données s’appuie notamment sur :

- Vues/Tables : `leVisiteur`, `Motif`, `TypePraticien`, `Specialite`, `Famille`, `medicament`, `mespraticiens`, `mesVisites`, `mesEchantillons`
- Procédures stockées : `ajouterRendezVous`, `supprimerRendezVous`, `modifierRendezVous`, `enregistrerBilanVisite`, `ajouterEchantillon`

## Lancer le projet

Depuis la racine du dépôt :

```bash
dotnet restore Gsb2026.slnx
dotnet build Gsb2026.slnx
dotnet run --project /home/runner/work/gsb/gsb/Interface/Interface.csproj
```

> Sur Linux/macOS, la compilation de `Interface` peut nécessiter `EnableWindowsTargeting=true` mais l’application WinForms reste destinée à Windows.

## Notes

- L’entrée applicative est `Interface/Program.cs`.
- La session chargée au login contient les données métier nécessaires à la navigation.
- Certaines fonctionnalités praticiens sont préparées mais non activées dans le menu (`FrmBase`).
