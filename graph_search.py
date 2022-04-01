graph = {
    'D' : ['J', 'G', 'F'],
    'J' : ['D'],
    'G' : ['D', 'E', 'H'],
    'H' : ['I', 'G'],
    'I' : ['H'],
    'E' : ['G'],
    'F' : ['M', 'K', 'D'],
    'M' : ['F'],
    'K' : ['F']
}

visited_dfs = []
visited_bfs = []
queue = []


# Depth-first search
def dfs(graph, node):
    global visited_dfs
    # if not visited
    if node not in visited_dfs:
        visited_dfs.append(node)
        # visiting other nodes
        for n in graph[node]:
            dfs(graph, n)
            
    
# Breadth-first search        
def bfs(graph, node):
    visited_bfs.append(node)
    queue.append(node)
    
    # while queue not empty
    while queue:
        s = queue.pop(0)
        
        # for every branch 
        for neighbor in graph[s]:
            if neighbor not in visited_bfs:
                visited_bfs.append(neighbor)
                queue.append(neighbor)
            
                   
dfs(graph, 'D')
print(f"Path in depth from vertex D: {visited_dfs}")

bfs(graph, 'F')
print(f"Path in width from vertex F: {visited_bfs}")