#include <vector>
#include<iostream>
#include<algorithm>

using namespace std;


    vector<vector<int>> answer;
    vector<int> preorder;
    vector<int> postorder;

class Node
{
public:
    int idx;
    int x;
    int y;
    Node* left;
    Node* right;

    Node(int inIdx, int inX, int inY)
    {
        idx = inIdx;
        x = inX;
        y = inY;
        left = NULL;
        right = NULL;
    }
    Node(int inIdx, int inX, int inY, Node& inLeft, Node& inRight)
    {
        idx = inIdx;
        x = inX;
        y = inY;
        left = &inLeft;
        right = &inRight;
    }
    ~Node() {};
};

bool compare(vector<int> a, vector<int> b)
{
    return a[2] > b[2];
}
 void PreOrderDFS(Node* node)
    {
        preorder.push_back(node->idx);

        if (node->left != NULL)
            PreOrderDFS(node->left);

        if (node->right != NULL)
            PreOrderDFS(node->right);
    }

    void PostOrderDFS(Node* node)
    {
        if (node->left != NULL)
            PostOrderDFS(node->left);

        if (node->right != NULL)
            PostOrderDFS(node->right);

        postorder.push_back(node->idx);

    }

    void TreeInsert(Node* Parent, Node* Child)
    {
        if (Child->x < Parent->x)
        {
            if (Parent->left != NULL)
                TreeInsert(Parent->left, Child);
            else
                Parent->left = Child;
        }
        else if (Child->x > Parent->x)
        {
            if (Parent->right != NULL)
                TreeInsert(Parent->right, Child);
            else
                Parent->right = Child;
        }
    }



class Solution
{
public:


 
};



   vector<vector<int>> solution(vector<vector<int>> nodeinfo) 
    {
        vector<vector<int>> list;

        for (int i = 0; i < nodeinfo.size();++i)
        {
            list.push_back({ {i + 1, nodeinfo[i][0], nodeinfo[i][1]} });
        }


        sort(list.begin(), list.end(), compare);
        
        vector<Node*> tree;

        Node* root = new Node(list[0][0], list[0][1], list[0][2]);

        tree.push_back(root);

        for (int i = 1; i < list.size(); ++i)
        {
            Node* newChild = new Node(list[i][0], list[i][1], list[i][2]);
            TreeInsert(*(tree.begin()), newChild);
        }

        PreOrderDFS(tree[0]);
        PostOrderDFS(tree[0]);

        answer.push_back(preorder);
        answer.push_back(postorder);


        for (auto i = preorder.begin(); i < preorder.end(); ++i) {
            cout << *i <<" ";
        }

        cout << endl;

        for (auto i = postorder.begin(); i < postorder.end(); ++i) {
            cout << *i << " ";
        }

        return answer;
    }
