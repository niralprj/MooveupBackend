# MooveupBackend
MooveupBackend is .Net core 6.0 Console application to search the shortest path and 
all the possbile path between given two nodes.
Project: UnidrectGraph_backend
Framework: .Net core 6.0 LTS
IDE used: Visual Studio 2022

# Example Output
Question 1 Answer: All the possible paths paths between A and H:
Path: A -> B -> C -> D -> E -> F -> G -> H
Path: A -> B -> C -> D -> E -> H
Path: A -> B -> C -> F -> E -> H
Path: A -> B -> C -> F -> G -> H
Path: A -> B -> D -> C -> F -> E -> H
Path: A -> B -> D -> C -> F -> G -> H
Path: A -> B -> D -> E -> F -> G -> H
Path: A -> B -> D -> E -> H
Path: A -> D -> B -> C -> F -> E -> H
Path: A -> D -> B -> C -> F -> G -> H
Path: A -> D -> C -> F -> E -> H
Path: A -> D -> C -> F -> G -> H
Path: A -> D -> E -> F -> G -> H
Path: A -> D -> E -> H
Path: A -> H

Question 2 Answer: Shortest path between A and H:
A -> H