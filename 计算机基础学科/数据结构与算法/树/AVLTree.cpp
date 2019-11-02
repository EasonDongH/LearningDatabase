#include <iostream>
using namespace std;

#define MAX(a,b) ( (a)<(b)? (b) : (a) )

typedef int ElementType;
typedef struct AVLNode *Position;
struct AVLNode {
	ElementType Data;
	int Height;
	Position Left, Right;
};
typedef Position AVLTree;

int GetHeight(AVLTree A) {
	if (A == nullptr)
		return 0;
	int left, right;
	left = GetHeight(A->Left) + 1;
	right = GetHeight(A->Right) + 1;
	return MAX(left, right);
}

/* 左单旋
 * A必有一个左子树，以A左子树B为根，A->Left指向B->Right，B->Right指向A
 * 更新A、B的高度，并将B作为新的根结点返回
 */
AVLTree SingleLeftRotation(AVLTree A) {
	AVLTree B = A->Left;
	A->Left = B->Right;
	B->Right = A;

	A->Height = MAX(GetHeight(A->Left), GetHeight(A->Right)) + 1;
	B->Height = MAX(GetHeight(B->Left), A->Height) + 1;//此时A的高度为B的右子树高度

	return B;
}

/* 右单旋
*  A必有一个右子树，以A右子树B为根，A->Right指向B->Left，B->Left指向A
* 更新A、B的高度，并将B作为新的根结点返回
*/
AVLTree SingleRightRotation(AVLTree A) {
	AVLTree B = A->Right;
	A->Right = B->Left;
	B->Left = A;

	A->Height = MAX(GetHeight(A->Left), GetHeight(A->Right)) + 1;
	B->Height = MAX(GetHeight(B->Right), A->Height) + 1;//此时A的高度为B的左子树高度

	return B;
}

/*
 * 左-右双旋
 * A必有一个左子树B，B必有一个右子树C
 * 先对B进行右单旋，再对A进行左单旋
 */
AVLTree DoubleLeftRightRotation(AVLTree A) {
	A->Left = SingleRightRotation(A->Left);
	return SingleLeftRotation(A);
}

/*
* 右-左双旋
* A必有一个右子树B，B必有一个左子树C
* 先对B进行左单旋，再对A进行右单旋
*/
AVLTree DoubleRightLeftRotation(AVLTree A) {
	A->Right = SingleLeftRotation(A->Right);
	return SingleRightRotation(A);
}

AVLTree Insert(AVLTree A, ElementType data) {
	if (A == nullptr) {
		A = (AVLTree)malloc(sizeof(struct AVLNode));
		A->Data = data;
		A->Height = 0;
		A->Left = A->Right = nullptr;
	}
	else if (data < A->Data) {
		A->Left = Insert(A->Left, data);//往左边插入，会使左边高度变高
		if (GetHeight(A->Left) - GetHeight(A->Right) > 1) {
			if (data < A->Left->Data)//元素插在A左边的左边，需要左单旋
				A = SingleLeftRotation(A);
			else//插在A左边的右边，需要左-右双旋
				A = DoubleLeftRightRotation(A);
		}
	}
	else if (A->Data<data) {
		A->Right = Insert(A->Right, data);//往右边插入，会使右边高度变高
		if (GetHeight(A->Left) - GetHeight(A->Right) < -1) {
			if (A->Right->Data < data)//元素插在A右边的右边，需要右单旋
				A = SingleRightRotation(A);
			else//插在A右边的左边，需要右-左单旋
				A = DoubleRightLeftRotation(A);
		}
	}

	A->Height = MAX(GetHeight(A->Left), GetHeight(A->Right)) + 1;
	
	return A;
}

int main() {
	int N, data;
	AVLTree A=nullptr;

	cin >> N;
	while (N--) {
		cin >> data;
		A = Insert(A, data);
	}
	cout << A->Data << endl;

	return 0;
}