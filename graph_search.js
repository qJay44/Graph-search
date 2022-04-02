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

let visited_dfs = [];
let visited_bfs = [];
let queue = [];

// Depth-first search
function dfs(graph, node) {
    if (!(visited_dfs.includes(node))) {
        visited_dfs.push(node);
        // visiting other nodes
        graph[node].forEach(n => {
            dfs(graph, n);
        });
    }
}

// Breadth-first search
function bfs(graph, node) {
    visited_bfs.push(node);
    queue.push(node);

    // while queue not empty
    while (queue.length != 0) {
        s = queue.shift();

        // for every branch
        graph[s].forEach(neighbor => {
            if (!(visited_bfs.includes(neighbor))) {
                visited_bfs.push(neighbor);
                queue.push(neighbor);
            }
        });
    }
}

dfs(graph, 'D');
console.log(`Path in depth from vertex D: ${visited_dfs}`);

bfs(graph, 'F');
console.log(`Path in width from vertex F: ${visited_bfs}`);