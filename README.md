# Corso_2024

Markdown Mermaid

# Prima lezione

## Corso dev c#

- Configurazione area di lavoro

- Configurazione versionamento# IndovinaAuto

- **Grassetto**
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

| Tabella | di    | prova | --    |
| ------- | ----- | ----- | ----- | --- |
| Header  | Title | Ciao  | Prova |
| 1       | 2     | 3     | 4     | 5   |
|         | quasi |

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


```mermaid
graph TD
A[Avvio del programma] --> B{Scelta del menu}

B -->|1| C[Visualizza partecipanti]
C --> B
B -->|2| D[Ordinamento partecipanti]
D --> E{Ordine discendente?}
E -->|Sì| F[Inverti ordine]
E -->|No| G[Ritorna al menu]
F --> G
G --> B
B -->|3| H[Ricerca partecipante]
H --> I{Partecipante presente?}
I -->|Sì| J[Stampa Presente]
I -->|No| K[Stampa Assente]
J --> B
K --> B
B -->|4| L[Menu Edita]
L --> M{Scelta del menu edit}
M -->|1| N[Aggiungi partecipante]
N --> O{Partecipante già presente?}
O -->|Sì| P[Stampa Già presente]
O -->|No| Q[Aggiungi alla lista]
P --> M
Q --> M
M -->|2| R[Elimina partecipante]
R --> S{Partecipante presente?}
S -->|Sì| T[Rimuovi partecipante]
S -->|No| U[Stampa Non presente]
T --> M
U --> M
M -->|3| V[Modifica partecipante]
V --> W{Partecipante presente?}
W -->|Sì| X[Modifica nome]
W -->|No| Y[Stampa Non presente]
X --> M
Y --> M
M -->|b| Z[Ritorna al menu principale]
Z --> B
B -->|q| AA[Fine del programma]
```

```mermaid
stateDiagram
    [*] --> MenuPrincipale
    
    state MenuPrincipale {
        [*] --> SceltaMenu
        SceltaMenu --> VisualizzaPartecipanti : '1'
        SceltaMenu --> Ordinamento : '2'
        SceltaMenu --> Ricerca : '3'
        SceltaMenu --> MenuEdita : '4'
        SceltaMenu --> Uscita : 'q'

        VisualizzaPartecipanti --> SceltaMenu : 'Qualsiasi tasto'
        
        state Ordinamento {
            [*] --> OrdinamentoAscendente
            OrdinamentoAscendente --> OrdinamentoDiscendente : 'd'
            OrdinamentoDiscendente --> SceltaMenu : 'Qualsiasi tasto'
            OrdinamentoAscendente --> SceltaMenu : 'Qualsiasi tasto'
        }
        
        Ricerca --> SceltaMenu : 'Qualsiasi tasto'
        
state MenuEdita {
    [*] --> SceltaMenuEdita
    SceltaMenuEdita --> AggiungiNome : '1'
    SceltaMenuEdita --> EliminaPartecipante : '2'
    SceltaMenuEdita --> ModificaPartecipante : '3'
    SceltaMenuEdita --> SceltaMenu : 'b'

    AggiungiNome --> SceltaMenuEdita : 'Qualsiasi tasto'
    EliminaPartecipante --> SceltaMenuEdita : 'Qualsiasi tasto'
    ModificaPartecipante --> SceltaMenuEdita : 'Qualsiasi tasto'
    }
}
    
    Uscita --> [*]

```