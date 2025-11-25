#include <string>
#include <vector>

using namespace std;

 int solution(int n, int s, int a, int b, vector<vector<int>> fares)
 {
     int answer = 0;
     int dist[201][201];
     const int INF = 20000000;

     for (auto i = 0; i <= n; ++i)
     {
         for (auto j = 0; j <= n; ++j)
         {
             dist[i][j] = INF;
             dist[i][i] = 0;
         }
     }
     
     for (auto i = fares.begin(); i < fares.end(); ++i) 
     {
         auto road = *i;

         dist[road[0]][road[1]] = road[2];
         dist[road[1]][road[0]] = road[2];
     }

     for (int k = 1; k <= n; ++k) 
     {
         for (auto i = 1; i <= n; ++i)
         { 
             for (auto j = 1; j <= n; ++j)
             {
                dist[i][j] = min(dist[i][j], dist[i][k] + dist[k][j]);
             }
         }
     }




     
     int minCost = dist[s][a] + dist[s][b];

     for (int node = 1; node <= n; ++node) 
     {
         minCost = std::min(minCost,dist[s][node] + dist[node][a] + dist[node][b]);
     }

     answer = minCost;
     return answer;
 }