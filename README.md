# PrismDemoD

Prism Demo mit DryIoc IOC, zum Vergleich mit Unity (PrismDemoU oder PrismDemo)

## Features
* Book, BookGroup; Books, Bookgroups. 
* (Original Rezept1 hat TabbedPage)

## Probleme
* Funktioniert nicht: gem. Muster Rezept1 (Unity), abgewandelt mit Books.json2
* Fkt. nicht mit DryIoc: OnNavigatedTO: Bookgroups = null
* Fkt. weder mit Newtonsoft.json 9.0.1 noch 10.0.2

>> ACHTUNG: bei Problemen mit Datenanzige (leere Books-Collection) immer kontrollieren: json-File als embedded und json-File UTF-8 ohne BOM !!!
