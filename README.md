# Workshop Memory - Exercices

## Resume global
Cette PR regroupe les exercices 1 a 6 du sujet dans un seul programme console.
Chaque exercice est isole dans une methode dediee (`RunExerciseX`) et le `Main` les execute sequentiellement.

## Details par exercice
Exercice 1 - Delegue
Un delegue `AdditionDelegate` reference `methode(int v1, int v2)` et l'invoque pour additionner deux valeurs.

Exercice 2a - Lambda + boucle for + threads
La closure sur la variable de boucle est corrigee en capturant `i` dans une variable locale `j`.
Chaque thread affiche le carre de `j` de 0 a 9.

Exercice 2b - Lambda
Une lambda `Func<int,int>` calcule le carre d'un entier et affiche le resultat.

Exercice 3 - Type anonyme
Creation d'un type anonyme `{ Id, Label }` et affichage de ses proprietes.

Exercice 4 - Delegues (simple, tableau, multicast)
Classes `A` et `B` avec `ma()` et `mb()`, delegue simple, tableau de delegues, delegue multicast.
Appels directs, puis via le delegue simple, le tableau, et enfin le multicast avec desabonnement.

Exercice 5 - Heap vs Stack
Deux methodes comparent les allocations et performances:
- Heap via `int[]`
- Stack via `stackalloc` et `Span<int>`
Le temps d'execution est mesure avec `Stopwatch`.

Exercice 6 - IDisposable + using
`DatabaseConnection` implemente `IDisposable`, `Dispose()` appelle `Close()`.
`RunExercise6` utilise un `using` pour garantir la fermeture automatique.

## Fonctionnement du programme
Le `Main` appelle `RunExercise1` a `RunExercise6` dans l'ordre.
Chaque methode execute un scenario simple et affiche son resultat dans la console.

## Implementation
Tout est centralise dans `Workshop_Memory/Program.cs` pour faciliter la lecture.
Les exercices sont decoupes en methodes privees afin de separer la logique et garder un flux d'execution clair.
