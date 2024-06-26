# Corso_2024
Markdown Mermaid

# Prima lezione
## Corso dev c#
- Configurazione area di lavoro

- Configurazione versionamento# IndovinaAuto

 - __Grassetto__
    - _Corsivo_
        - **Bold**
 - Prova
    - Riprova
        - Provina
            - Provetta
                - Provucola
                    - Assorreta

## Flaggatura
- [ ] Non flaggata
- [x] Flaggata

#Backtick
Alt + 96 `
```c#
Codice inquadrettato
Total 3 (delta 2), reused 0 (delta 0), pack-reused 0
remote: Resolving deltas: 100% (2/2), completed with 2 local objects.
To https://github.com/Pozzame/Cicli.git
   4449df6..f31e015  main -> main
branch 'main' set up to track 'origin/main'. 
```

[Link cliccabile](Linketto)


<!-- Commento-->

|Tabella|di|prova|--|
|------|---|---|----|
|Header|Title|Ciao|Prova|
|1|2|3|4|5|
||quasi|

<details>
<summary>Nascosto</summary>
Testo imboscato
<details>
<summary>Nascosto</summary>
Testo più imboscato
</details>
Un po' meno
</details>


```mermaid
flowchart TD
start --> stop
```
```mermaid
%%{init: {"flowchart": {"htmlLabels": false}} }%%
flowchart LR
    markdown["`This **is** _Markdown_`"]
    newLines["`Line1
    Line 2
    Line 3`"]
    markdown --> newLines
    
```
```mermaid
journey
    title My working day
    section Go to work
      Make tea: 5: Me
      Go upstairs: 3: Me
      Do work: 1: Me, Cat
    section Go home
      Go downstairs: 5: Me
      Sit down: 5: Me
```
