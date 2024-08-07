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
```mermaid
flowchart TD
    A[Start] --> B[Initialize variables]
    B --> C[Display menu]
    C --> D{User input}
    D --> |1| E[Display participants]
    E --> C
    D --> |2| F[Sort participants]
    F --> F1[Ask for descending order]
    F1 --> |Yes| F2[Reverse list]
    F2 --> C
    F1 --> |No| C
    D --> |3| G[Search participant]
    G --> H[Check if participant exists]
    H --> I[Display result]
    I --> C
    D --> |4| J[Enter edit menu]
    J --> K{Edit menu input}
    K --> |1| L[Add participant]
    L --> M[Check if participant exists]
    M --> N{Exists?}
    N --> |Yes| O[Display already exists]
    O --> K
    N --> |No| P[Add to list]
    P --> K
    K --> |2| Q[Remove participant]
    Q --> R[Check if participant exists]
    R --> S{Exists?}
    S --> |Yes| T[Remove from list]
    T --> K
    S --> |No| U[Display not exists]
    U --> K
    K --> |3| V[Edit participant]
    V --> W[Check if participant exists]
    W --> X{Exists?}
    X --> |Yes| Y[Read new name]
    Y --> Z[Replace name in list]
    Z --> K
    X --> |No| AA[Display not in list]
    AA --> K
    K --> |b| AB[Back to main menu]
    AB --> C
    D --> |5| AC[Create teams]
    AC --> AD[Display participants table]
    AD --> AE[Distribute participants randomly]
    AE --> AF[Create teams table]
    AF --> AG[Display teams table]
    AG --> C
    D --> |q| AH[Exit]
    D --> |default| AI[Invalid input]
    AI --> C
```

```mermaid
flowchart TD
    A[Start] --> B[Initialize variables]
    B --> C[Read participants from file]
    C --> D[Clear console]
    D --> E{Show main menu}
    
    E --> |Visualiza partecipanti| F[Display participants]
    F --> D

    E --> |Ordina| G[Sort participants]
    G --> H[Ask for descending order]
    H --> |Yes| I[Reverse list]
    H --> |No| D

    I --> D

    E --> |Ricerca| J[Search participant]
    J --> K[Check if participant exists]
    K --> L[Display result]
    L --> D

    E --> |Edita| M{Show edit menu}
    M --> |Aggiunta nome| N[Add participant]
    N --> O[Check if participant exists]
    O --> |Yes| P[Display already exists]
    O --> |No| Q[Add to list]
    P --> M
    Q --> M
    
    M --> |Elimina partecipante| R[Remove participant]
    R --> S[Check if participant exists]
    S --> |Yes| T[Remove from list]
    S --> |No| U[Display not exists]
    T --> M
    U --> M

    M --> |Modifica| V[Edit participant]
    V --> W[Check if participant exists]
    W --> |Yes| X[Read new name]
    X --> Y[Replace name in list]
    Y --> M
    W --> |No| Z[Display not in list]
    Z --> M

    M --> |Back| D
    
    E --> |Salva lista| AA[Save participants to file]
    AA --> AB[Display save confirmation]
    AB --> D

    E --> |Menù squadre| AC{Show team menu}
    AC --> |Crea squadre| AD[Create teams]
    AD --> AE[Distribute participants randomly]
    AE --> AF[Display teams]
    AF --> AC

    AC --> |Salva squadre| AG[Save teams to file]
    AG --> AH[Display save confirmation]
    AH --> AC

    AC --> |Ricarica partecipanti| AI[Reload participants from file]
    AI --> AJ[Display reload confirmation]
    AJ --> AC

    AC --> |Back| D

    E --> |Esci| AK[End]

classDef default fill:#f0f,stroke:#333,stroke-width:4px;
```