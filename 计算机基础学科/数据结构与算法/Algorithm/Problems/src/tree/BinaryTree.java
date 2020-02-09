package tree;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.Queue;

/**
 * @author EasonDongH
 * @date 2020/2/7 10:31
 */
public class BinaryTree {

    public static final Integer NULL = null;

    private static class BinaryTreeNode {
        private Integer value;
        private BinaryTreeNode left, right;

        public BinaryTreeNode(Integer value) {
            this.value = value;
        }

        public Integer getValue() {
            return value;
        }

        public void setValue(Integer value) {
            this.value = value;
        }

        public BinaryTreeNode getLeft() {
            return left;
        }

        public void setLeft(BinaryTreeNode left) {
            this.left = left;
        }

        public BinaryTreeNode getRight() {
            return right;
        }

        public void setRight(BinaryTreeNode right) {
            this.right = right;
        }
    }

    /**
     * 将列表转换为二叉树
     * 列表需要满足：
     * 1. 以层序的顺序表示完美二叉树
     * 2. 空节点为null
     * @param list
     * @return
     */
    public static BinaryTreeNode convertListToBinaryTree(List<Integer> list) {
        if(list == null || list.size() <= 0) {
            return null;
        }
        int iIndex = 0;
        Queue<BinaryTreeNode> queue = new ArrayDeque<>();
        BinaryTreeNode root = new BinaryTreeNode(list.get(iIndex++));
        queue.offer(root);
        while (iIndex < list.size() && !queue.isEmpty()) {
            BinaryTreeNode cur = queue.poll();
            if(cur != null) {
                Integer val = list.get(iIndex++);
                BinaryTreeNode left = val == null? null : new BinaryTreeNode(val);
                val = list.get(iIndex++);
                BinaryTreeNode right = val == null? null : new BinaryTreeNode(val);
                cur.setLeft(left);cur.setRight(right);
                queue.offer(left);queue.offer(right);
            }
        }
        return root;
    }

    /**
     * 将二叉树转为层序表示的完美二叉树
     * @param root
     * @return
     */
    public static List<Integer> convertBinaryTreeToList(BinaryTreeNode root){
        if(root == null) {
            return null;
        }
        List<Integer> list = new ArrayList<>();
        Queue<BinaryTreeNode> queue = new ArrayDeque<>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            BinaryTreeNode cur = queue.poll();
            list.add(cur.getValue());
            if(cur != null) {
                queue.offer(cur.getLeft());
                queue.offer(cur.getRight());
            }
        }
        return list;
    }
}
