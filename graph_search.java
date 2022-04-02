import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Queue;

public class graph_search {

    private static Map<Character, char[]> Graph = new HashMap<Character, char[]>();
    private static List<Character> visited_dfs = new ArrayList<Character>();
    private static List<Character> visited_bfs = new ArrayList<Character>();
    private static Queue<Character> queue = new LinkedList<>();
    public static void main(String[] args) {
        Graph.put('D', new char[] {'J', 'G', 'F'});
        Graph.put('J', new char[] {'D'});
        Graph.put('G', new char[] {'D', 'E', 'H'});
        Graph.put('H', new char[] {'I', 'G'});
        Graph.put('I', new char[] {'H'});
        Graph.put('E', new char[] {'G'});
        Graph.put('F', new char[] {'M', 'K', 'D'});
        Graph.put('M', new char[] {'F'});
        Graph.put('K', new char[] {'F'});

        dfs(Graph, 'D');
        System.out.println(String.format("Path in depth from vertex D: %s", visited_dfs));

        bfs(Graph, 'F');
        System.out.println(String.format("Path in width from vertex F: %s", visited_bfs));
    };

    // Depth-first search
    private static void dfs(Map<Character, char[]> graph, char node) {
        // if not visited
        if (!visited_dfs.contains(node)) {
            visited_dfs.add(node);
            // visiting other nodes
            for (char neighbor : Graph.get(node)) {
                dfs(Graph, neighbor);    
            }
        }
    }

    // Breadth-first search
    private static void bfs(Map<Character, char[]> graph, char node) {
        visited_bfs.add(node);
        queue.add(node);

        // while queue not empty
        while (queue.size() != 0) {
            char s = queue.remove();

            // for every branch
            for (char neighbor : Graph.get(s)) {
                if (!visited_bfs.contains(neighbor)) {
                    visited_bfs.add(neighbor);
                    queue.add(neighbor);
                }
            }
        }
    }
}