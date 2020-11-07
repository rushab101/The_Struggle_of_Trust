#include <vector>
#include <iostream>
#include <cstdlib>
using namespace std;
//Time Complexity O(n)-> n represents the total number of nodes in the tree

//struct to create the binary tree
struct Node
{
  int val;
  Node *left;
  Node *right;
};

//used to create the tree
Node* newNode(int val)
{
    Node* node = (Node*)malloc(sizeof(Node));
    node->val = val;
    node->left = node->right = nullptr;
    return node;
    
}
//insert values into the tree following the property the left child is smaller than the parent, and right child is larger than the parent (BST)
Node* insertIntoTree(Node* root, int val)
{
    if (root == nullptr) return newNode(val);
    if (root->val > val) root->left = insertIntoTree(root->left,val);
    if (root->val < val) root->right = insertIntoTree(root->right,val);
    return root;
}

//used to determine the lowest common ancestor between the two nodes given
Node* distance(Node* root, int nodeA, int nodeB){
    if (root == nullptr) return root;
    if (root->val == nodeA || root->val == nodeB) return root;
    Node* left = distance(root->left,nodeA,nodeB);
    Node* right = distance(root->right,nodeA,nodeA);
    if (left!=nullptr && right!=nullptr) return root;
    if (left == nullptr && right == nullptr) return nullptr;
    if (left != nullptr) return distance(root->left,nodeA,nodeB);
    return distance(root->right,nodeA,nodeB);
}
//used to print the tree
void inOrder(Node* root)
{
    if (root != nullptr)
    {
        inOrder(root->left);
      //  cout << root->val << " "; //used to print the tree to ensure its correct
        inOrder(root->right);
    }
}
//used to find the distance from node to lowestCommonAncestor
int find_dist(Node* root, int find, int level)
{
    if (root == nullptr) return -1;
    if (root->val == find) return level;
    int l = find_dist(root->left,find,level+1);
    if (l == -1)
        return find_dist(root->right,find,level+1); 
    return l;
}

//return the total distance between the two nodes
int BSTdistance(const std::vector<int>& values, int nodeA, int nodeB)
{
    // TODO your code here
    
    Node* root = nullptr;
    for (int i: values)
    root = insertIntoTree(root,i);
    inOrder(root);
    Node* lca = distance(root,nodeA,nodeB); //first find the lowest commen ancestor between the two trees
    int dist1= find_dist(lca,nodeA,0); //from the lowest common ancestor determine the distance it takes to get to nodeA
    int dist2 = find_dist(lca,nodeB,0); //from the lowest common ancestor determine the distance it takes to get to nodeB
   // cout << dist1 + dist2;
    return dist1 + dist2; //the total distance is the summutation of dist1 and dist2
}


int main ()
{
     cout << BSTdistance({ 8, 7, 13, 6, 2, 5, 1, 9, 11, 3, 4, 10}, 4, 2); //used to print the answer
}