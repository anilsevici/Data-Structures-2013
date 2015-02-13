using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeTest
{

    // Düğüm Sınıfı
    class TreeNode
    {
        public int data;
        public TreeNode leftChild;
        public TreeNode rightChild;
        public void displayNode() { Console.Write(" " + data + " "); }
    }

    // Agaç Sınıfı
    class Tree
    {
        private TreeNode root;
        public int sayi;
        public int düzey;
        public int toplamDerinlik;
        public int dugumSayisi;


        public Tree() { root = null; }

        public TreeNode getRoot()
        { return root; }

        // Agacın preOrder Dolasılması
        public void preOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                localRoot.displayNode();
                preOrder(localRoot.leftChild);
                preOrder(localRoot.rightChild);
            }
        }

        // Agacın inOrder Dolasılması
        public void inOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                inOrder(localRoot.rightChild);
                localRoot.displayNode();
                inOrder(localRoot.leftChild);
            }
        }

        // Agacın postOrder Dolasılması
        public void postOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                postOrder(localRoot.leftChild);
                postOrder(localRoot.rightChild);
                localRoot.displayNode();
            }
        }

        // Agaca bir dügüm eklemeyi saglayan metot
        public void insert(int newdata)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (newdata < current.data)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } // end while
            } // end else not root
        } // end insert()

        public void düzeyListele(TreeNode etkin, int d)
        {
            if (etkin != null)
            {
                d = d + 1;
                düzeyListele(etkin.leftChild, d);
                Console.WriteLine(" " + etkin.data + " " + d + ". düzeyde");
                düzeyListele(etkin.rightChild, d);
            }
        }

        public void düzeyListele2(TreeNode etkin)
        {
            if (etkin != null)
            {
                düzey = düzey + 1;
                düzeyListele2(etkin.leftChild);
                Console.WriteLine(" " + etkin.data + " " + düzey + ". düzeyde");
                düzeyListele2(etkin.rightChild);
                düzey = düzey - 1;
            }
        }

        public int Nodes_count(TreeNode etkin)//Dügüm sayısı bulma
        {
            int count = 0;
            if (etkin != null)
            {
                count = 1 + Nodes_count(etkin.leftChild) + Nodes_count(etkin.rightChild);
            }
            return count;
        }


        public int countLeaves(TreeNode etkin)//Yaprak sayısı bulma
        {
            if (etkin == null)
                return 0;
            if (etkin.leftChild == null && etkin.rightChild == null)
            {
                return 1;
            }
            else
            {
                return countLeaves(etkin.leftChild) + countLeaves(etkin.rightChild);
            }
        }

        public int findHeight(TreeNode etkin)//Derinlik bulma
        {
            if (etkin == null)
                return -1;

            int lefth = findHeight(etkin.leftChild);
            int righth = findHeight(etkin.rightChild);

            if (lefth > righth)
                return lefth + 1;
            else
                return righth + 1;
        }
        public double ortalamDerinlikHesaplama(TreeNode etkin)
        {
            if (etkin != null)
            {
                toplamDerinlik += ++düzey;
                dugumSayisi++;
                ortalamDerinlikHesaplama(etkin.leftChild);
                ortalamDerinlikHesaplama(etkin.rightChild);
                düzey = düzey - 1;

            } if (etkin == this.getRoot())

                return (double)toplamDerinlik / dugumSayisi;
            else return 0;
        }





    } // class Tree

    // Test Sınıfı
    class TreeTest
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            Tree agac = new Tree();

            // Ağaca 10 tane sayı yerleştirilmesi
            Console.WriteLine("Sayılar : ");
            for (int i = 0; i < 10; ++i)
            {
                int sayi = (int)(r.Next(100));
                Console.Write(sayi + " ");
                agac.insert(sayi);
            };

            Console.Write("\nAgacın InOrder Dolasılması : ");
            agac.inOrder(agac.getRoot());
            Console.Write("\nAgacın PreOrder Dolasılması : ");
            agac.preOrder(agac.getRoot());
            Console.Write("\nAgacın PostOrder Dolasılması : ");
            agac.postOrder(agac.getRoot());
            Console.WriteLine();

            Console.WriteLine("Dugum sayisi:{0}", agac.Nodes_count(agac.getRoot()));
            Console.WriteLine("Yaprak sayisi:{0}", agac.countLeaves(agac.getRoot()));
            Console.WriteLine("Agacın derinligi:{0}",agac.findHeight(agac.getRoot()));
            Console.WriteLine("Ortalama derinlik hesaplama:{0}", agac.ortalamDerinlikHesaplama(agac.getRoot()));

            //agac.düzeyListele(agac.getRoot(), -1);

            //agac.düzey = -1;
            //agac.düzeyListele2(agac.getRoot());

            Console.ReadKey();
        }
    }
}
