using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTreeMap
{
    public abstract class TreeMapComparer<T> : IComparer<T>
    {
        public abstract int Compare(T a, T b);
    }

    public class BaseComp : TreeMapComparer<int>
    {
        public override int Compare(int a, int b)
        {
            return a - b;
        }
    }

    public class TreeNode<K, V> 
    {

        public K key { get; set; }
        public V value { get; set; }
        public TreeNode<K, V> left;         //требуется для работы рекурсии
        public TreeNode<K, V> right;        //Эдуард Романович уведомлен

        public TreeNode(K ky, V val, TreeNode<K, V> lft, TreeNode<K, V> rght)
        {
            key = ky;
            value = val;
            left = lft;
            right = rght;
        }


    }

    public class MyTreeMap<K, V> : MyCollection.IMyNavigableMap<K, V>, MyCollection.IExceptions //where T : IComparable
    {
        private TreeMapComparer<K> comparer;
        private TreeNode<K, V> root;
        private int size;


        public MyTreeMap()
        {
            comparer = null;
            root = null;
            size = 0;
        }

        public MyTreeMap(TreeMapComparer<K> comp)
        {
            comparer = comp;
            root = null;
            size = 0;
        }


        public void Clear()
        {
            root = null;
            size = 0;
        }

        public bool ContainsKey(object key)
        {
            return ContainsKeyR((K)key, root);


            bool ContainsKeyR(K ky, TreeNode<K, V> node)
            {
                if (node == null) return false;
                if (comparer.Compare(ky, node.key) == 0) return true;
                return ContainsKeyR((K)key, node.left) || ContainsKeyR((K)key, node.right);
            }
        }

        public bool ContainsValue(object value)
        {
            return ContainsValueR((V)value, root);


            bool ContainsValueR(object val, TreeNode<K, V> node)
            {
                if (node == null) return false;
                if (node.value.Equals(val)) return true;
                return ContainsValueR(val, node.left) || ContainsValueR(val, node.right);
            }
        }

        public MyVector.MyVector<MyHashMap.Entry<K, V>> EntrySet()
        {
            MyVector.MyVector<TreeNode<K, V>> mid = new MyVector.MyVector<TreeNode<K, V>>();
            TreeNode<K, V>[] output = new TreeNode<K, V>[size];

            EntrySetSearch(ref mid, root);

            void EntrySetSearch(ref MyVector.MyVector<TreeNode<K, V>> vec, TreeNode<K, V> node)
            {
                if (node == null) return;
                EntrySetSearch(ref vec, node.left);
                vec.Add(node);
                EntrySetSearch(ref vec, node.right);
            }

            //for (int i = 0; i < mid.Size(); i++)
            //{
            //    output[i] = mid.Get(i);
            //}

            MyVector.MyVector<MyHashMap.Entry<K, V>> outline = new MyVector.MyVector<MyHashMap.Entry<K, V>>();

            for (int i = 0; i < output.Length; i++)
            {
                MyHashMap.Entry<K, V> entry = new MyHashMap.Entry<K, V>();

                entry.key = output[i].key;
                entry.value = output[i].value;

                outline.Add(entry);
            }

            return outline;
        }
 
        public V Get(object key)
        {
            V output = default;
            GetR(key, root, ref output);
            return output;


            void GetR(object ky, TreeNode<K, V> node, ref V val)
            {
                if (node == null) return;
                if (ky.Equals(node.key)) val = node.value;
                GetR(ky, node.left, ref val);
                GetR(ky, node.right, ref val);

            }
        }
        
        public bool IsEmpty()
        {
            if (size > 0) return false;
            return true;
        }

        public K[] KeySet()
        {
            MyVector.MyVector<K> mid = new MyVector.MyVector<K>();
            K[] output = new K[size];

            KeySetSearch(ref mid, root);

            void KeySetSearch(ref MyVector.MyVector<K> vec, TreeNode<K, V> node)
            {
                if (node == null) return;
                KeySetSearch(ref vec, node.left);
                vec.Add(node.key);
                KeySetSearch(ref vec, node.right);
            }

            for (int i = 0; i < mid.Size(); i++)
            {
                output[i] = mid.Get(i);
            }

            return output;
        }

        public void Put(K key, V value)
        {
            if (root == null)
            {
                TreeNode<K, V> input = new TreeNode<K, V>(key, value, null, null);
                size++;
                root = input;
            }
            else
            {
                InputSearch(key, value, root);
            }



            void InputSearch(K ky, V val, TreeNode<K, V> node)
            {
                if (comparer.Compare(ky, node.key) == 0) return;
                if (comparer.Compare(ky, node.key) > 0)
                {
                    
                    if (node.right == null)
                    {
                        node.right = new TreeNode<K, V>(ky, val, null, null);
                        size++;
                    }
                    else
                    {
                        InputSearch(key, value, node.right);
                    }
                }
                if (comparer.Compare(ky, node.key) < 0)
                {
                    
                    if (node.left == null)
                    {
                        node.left = new TreeNode<K, V>(ky, val, null, null);
                        size++;
                    }
                    else
                    {
                        InputSearch(key, value, node.left);
                    }
                }
            }
        }

        public void PutAll(MyCollection.IMyMap<K, V> m)
        {
            K[] keys = m.KeySet();
            V[] vals = m.Values();

            for (int i = 0; i < vals.Length; i++)
            {
                Put(keys[i], vals[i]);
            }

        }

        public void Remove(object key)
        {
            if (IsEmpty()) Empty();

            bool srch = true;
            RemoveR(key, ref root, ref srch);
            

            void RemoveR(object ky, ref TreeNode<K, V> node, ref bool flag)
            {
                if (node == null) return;
                if (comparer.Compare((K)ky, node.key) == 0)
                {
                    
                    flag = false;
                    size--;
                    if (node.left == null && node.right == null)
                    {
                        //Console.WriteLine("tst1");
                        node = null;

                        return;
                    }
                    if (node.left == null)
                    {
                        //Console.WriteLine("tst2");
                        node = node.right;

                        return;
                    }
                    if (node.right == null)
                    {
                        //Console.WriteLine("tst3");
                        node = node.left;

                        return;
                    }
                    if (node.left != null && node.right != null)
                    {
                        //Console.WriteLine("tst4");
                        //TreeNode<K, V> minSrch = MinSearch(node);
                        //node.value = minSrch.value;
                        //Remove(minSrch.key);

                        TreeNode < K, V > temp = Shift(ref node.right);

                        node.key = temp.key;
                        node.value = temp.value;

                        return;
                    }
                }

                if (flag) RemoveR(ky, ref root.left, ref flag);
                if (flag) RemoveR(ky, ref root.right, ref flag);
            }

            //TreeNode<K, V> MinSearch(TreeNode<K, V> node)
            //{
            //    if (node.left == null/* && node.right == null*/)
            //    {
            //        V output = node.value;
            //        node = null;
            //    }
            //    //if (node.left == null)
            //    //{
            //    //    return MinSearch(node.right);
            //    //}
            //    return MinSearch(node.left);
            //}

            //void Shift(ref TreeNode<K, V> node)
            //{
            //    if (node.left != null)
            //    {
            //        node.key = node.left.key;
            //        node.value = node.left.value;

            //        Shift(ref node.left);
            //    }
            //    else
            //    {
            //        if (node.right != null)
            //        {
            //            node = node.right;
            //        }
            //        else
            //        {
            //            node = null;
            //        }
            //    }
            //}

            TreeNode<K, V> Shift(ref TreeNode<K, V> node)
            {
                if (node.left == null && node.right == null)
                {
                    TreeNode<K, V> output = new TreeNode<K, V>(node.key, node.value, node.left, node.right);

                    node = null;

                    return output;
                }
                if (node.left == null && node == root)
                {
                    TreeNode<K, V> output = new TreeNode<K, V>(node.key, node.value, node.left, node.right);

                    node = node.right;

                    return output;
                }
                if (node.left == null && node != null)
                {
                    TreeNode<K, V> output = new TreeNode<K, V>(node.key, node.value, node.left, node.right);  //???

                    node = node.right;

                    return output;
                }
                return Shift(ref node.left);
            }
        }

        public V[] Values()
        {
            MyVector.MyVector<MyHashMap.Entry<K, V>> med = EntrySet();

            V[] output = new V[med.Size()];

            for (int i = 0; i < med.Size(); i++)
            {
                output[i] = med.Get(i).value;
            }

            return output;
        }


        public int Size()
        {
            return size;
        }

        public K FirstKey()
        {
            if (IsEmpty()) Empty();

            K FirstSearchR(TreeNode <K, V> node)
            {
                if (node.left == null && node.right == null)
                {
                    return node.key;
                }
                if (node.left == null && node == root)
                {
                    return node.key;
                }
                if (node.left == null)
                {
                    return FirstSearchR(node.right);
                }
                return FirstSearchR(node.left);
            }

            return FirstSearchR(root);
        }

        public K LastKey()
        {
            if (IsEmpty()) Empty();

            K LastSearchR(TreeNode<K, V> node)
            {
                if (node.left == null && node.right == null)
                {
                    return node.key;
                }
                if (node.right == null && node == root)
                {
                    return node.key;
                }
                if (node.right == null)
                {
                    return LastSearchR(node.left);
                }
                return LastSearchR(node.right);
            }

            return LastSearchR(root);
        }

        public K[] HeadMap(K end)
        {
            MyVector.MyVector<TreeNode<K, V>> search = new MyVector.MyVector<TreeNode<K, V>>();

            HeadSearchR(root, ref search, end);

            void HeadSearchR(TreeNode<K, V> node, ref MyVector.MyVector<TreeNode<K, V>> srch, K nd)
            {
                if (node == null)
                {
                    return;
                }

                HeadSearchR(node.left, ref srch, nd);

                if (comparer.Compare(nd, node.key) > 0) srch.Add(node);

                HeadSearchR(node.right, ref srch, nd);
            }

            K[] searchA = new K[search.Size()];

            for (int i = 0; i < searchA.Length; i++)
            {
                searchA[i] = search.Get(i).key;
            }

            return searchA;
        }

        public K[] SubMap(K start, K end)
        {
            MyVector.MyVector<TreeNode<K, V>> search = new MyVector.MyVector<TreeNode<K, V>>();

            HeadSearchR(root, ref search, start, end);

            void HeadSearchR(TreeNode<K, V> node, ref MyVector.MyVector<TreeNode<K, V>> srch, K strt, K nd)
            {
                if (node == null)
                {
                    return;
                }

                HeadSearchR(node.left, ref srch, strt, nd);

                if (comparer.Compare(nd, node.key) > 0 && comparer.Compare(node.key, strt) >= 0) srch.Add(node);

                HeadSearchR(node.right, ref srch, strt, nd);
            }

            K[] searchA = new K[search.Size()];

            for (int i = 0; i < searchA.Length; i++)
            {
                searchA[i] = search.Get(i).key;
            }

            return searchA;
        }

        public K[] TailMap(K start)
        {
            MyVector.MyVector<TreeNode<K, V>> search = new MyVector.MyVector<TreeNode<K, V>>();

            HeadSearchR(root, ref search, start);

            void HeadSearchR(TreeNode<K, V> node, ref MyVector.MyVector<TreeNode<K, V>> srch, K strt)
            {
                if (node == null)
                {
                    return;
                }

                HeadSearchR(node.left, ref srch, strt);

                if (comparer.Compare(node.key, strt) > 0) srch.Add(node);

                HeadSearchR(node.right, ref srch, strt);
            }

            K[] searchA = new K[search.Size()];

            for (int i = 0; i < searchA.Length; i++)
            {
                searchA[i] = search.Get(i).key;
            }

            return searchA;
        }

        public MyHashMap.Entry<K, V> LowerEntry(K key)
        {
            TreeNode<K, V> output = null;
            bool srch = true;

            LowerSearchR(root, key, ref output, ref srch);

            void LowerSearchR(TreeNode<K, V> node, K ky, ref TreeNode<K, V> put, ref bool flag)
            {
                if (node == null)
                {
                    return;
                }
                if (comparer.Compare(ky, node.key) > 0 && flag)
                {
                    flag = false;
                    put = node;
                }
                if (flag) LowerSearchR(node.left, ky, ref put, ref flag);
                if (flag) LowerSearchR(node.right, ky, ref put, ref flag);
            }

            MyHashMap.Entry<K, V> outputE = new MyHashMap.Entry<K, V>();

            outputE.key = output.key;
            outputE.value = output.value;

            return outputE;
        }

        public MyHashMap.Entry<K, V> FloorEntry(K key)
        {
            TreeNode<K, V> output = null;
            bool srch = true;

            LowerSearchR(root, key, ref output, ref srch);

            void LowerSearchR(TreeNode<K, V> node, K ky, ref TreeNode<K, V> put, ref bool flag)
            {
                if (node == null)
                {
                    return;
                }
                if (comparer.Compare(ky, node.key) >= 0 && flag)
                {
                    flag = false;
                    put = node;
                }
                if (flag) LowerSearchR(node.left, ky, ref put, ref flag);
                if (flag) LowerSearchR(node.right, ky, ref put, ref flag);
            }

            MyHashMap.Entry<K, V> outputE = new MyHashMap.Entry<K, V>();

            outputE.key = output.key;
            outputE.value = output.value;

            return outputE;
        }

        public MyHashMap.Entry<K, V> HigherEntry(K key)
        {
            TreeNode<K, V> output = null;
            bool srch = true;

            LowerSearchR(root, key, ref output, ref srch);

            void LowerSearchR(TreeNode<K, V> node, K ky, ref TreeNode<K, V> put, ref bool flag)
            {
                if (node == null)
                {
                    return;
                }
                if (comparer.Compare(node.key, ky) > 0 && flag)
                {
                    flag = false;
                    put = node;
                }
                if (flag) LowerSearchR(node.left, ky, ref put, ref flag);
                if (flag) LowerSearchR(node.right, ky, ref put, ref flag);
            }

            MyHashMap.Entry<K, V> outputE = new MyHashMap.Entry<K, V>();

            outputE.key = output.key;
            outputE.value = output.value;

            return outputE;
        }

        public MyHashMap.Entry<K, V> CeilingEntry(K key)
        {
            TreeNode<K, V> output = null;
            bool srch = true;

            LowerSearchR(root, key, ref output, ref srch);

            void LowerSearchR(TreeNode<K, V> node, K ky, ref TreeNode<K, V> put, ref bool flag)
            {
                if (node == null)
                {
                    return;
                }
                if (comparer.Compare(node.key, ky) >= 0 && flag)
                {
                    flag = false;
                    put = node;
                }
                if (flag) LowerSearchR(node.left, ky, ref put, ref flag);
                if (flag) LowerSearchR(node.right, ky, ref put, ref flag);
            }

            MyHashMap.Entry<K, V> outputE = new MyHashMap.Entry<K, V>();

            outputE.key = output.key;
            outputE.value = output.value;

            return outputE;
        }

        public K LowerKey(K key)
        {
            K output = default;
            bool srch = true;

            LowerSearchR(root, key, ref output, ref srch);

            void LowerSearchR(TreeNode<K, V> node, K ky, ref K put, ref bool flag)
            {
                if (node == null)
                {
                    return;
                }
                if (comparer.Compare(ky, node.key) > 0 && flag)
                {
                    flag = false;
                    put = node.key;
                }
                if (flag) LowerSearchR(node.left, ky, ref put, ref flag);
                if (flag) LowerSearchR(node.right, ky, ref put, ref flag);
            }

            return output;
        }

        public K FloorKey(K key)
        {
            K output = default;
            bool srch = true;

            LowerSearchR(root, key, ref output, ref srch);

            void LowerSearchR(TreeNode<K, V> node, K ky, ref K put, ref bool flag)
            {
                if (node == null)
                {
                    return;
                }
                if (comparer.Compare(ky, node.key) >= 0 && flag)
                {
                    flag = false;
                    put = node.key;
                }
                if (flag) LowerSearchR(node.left, ky, ref put, ref flag);
                if (flag) LowerSearchR(node.right, ky, ref put, ref flag);
            }

            return output;
        }

        public K HigherKey(K key)
        {
            K output = default;
            bool srch = true;

            LowerSearchR(root, key, ref output, ref srch);

            void LowerSearchR(TreeNode<K, V> node, K ky, ref K put, ref bool flag)
            {
                if (node == null)
                {
                    return;
                }
                if (comparer.Compare(node.key, ky) > 0 && flag)
                {
                    flag = false;
                    put = node.key;
                }
                if (flag) LowerSearchR(node.left, ky, ref put, ref flag);
                if (flag) LowerSearchR(node.right, ky, ref put, ref flag);
            }

            return output;
        }

        public K CeilingKey(K key)
        {
            K output = default;
            bool srch = true;

            LowerSearchR(root, key, ref output, ref srch);

            void LowerSearchR(TreeNode<K, V> node, K ky, ref K put, ref bool flag)
            {
                if (node == null)
                {
                    return;
                }
                if (comparer.Compare(node.key, ky) >= 0 && flag)
                {
                    flag = false;
                    put = node.key;
                }
                if (flag) LowerSearchR(node.left, ky, ref put, ref flag);
                if (flag) LowerSearchR(node.right, ky, ref put, ref flag);
            }

            return output;
        }

        public TreeNode<K, V> PollFirstEntry()
        {
            if (IsEmpty()) Empty();

            TreeNode<K, V> FirstSearchR(TreeNode<K, V> node)
            {
                if (node.left == null && node.right == null)
                {
                    TreeNode<K, V> output = node;

                    Remove(node.key);

                    return output;
                }
                if (node.left == null && node == root)
                {
                    TreeNode<K, V> output = node;

                    Remove(node.key);

                    return output;
                }
                if (node.left == null)
                {
                    return FirstSearchR(node.right);
                }
                return FirstSearchR(node.left);
            }

            return FirstSearchR(root);
        }

        public TreeNode<K, V> PollLastEntry()
        {
            if (IsEmpty()) Empty();

            TreeNode<K, V> LastSearchR(TreeNode<K, V> node)
            {
                if (node.left == null && node.right == null)
                {
                    TreeNode<K, V> output = node;

                    Remove(node.key);

                    return output;
                }
                if (node.right == null && node == root)
                {
                    TreeNode<K, V> output = node;

                    Remove(node.key);

                    return output;
                }
                if (node.right == null)
                {
                    return LastSearchR(node.left);
                }
                return LastSearchR(node.right);
            }

            return LastSearchR(root);
        }

        public TreeNode<K, V> FirstEntry()
        {
            if (IsEmpty()) Empty();

            TreeNode<K, V> FirstSearchR(TreeNode<K, V> node)
            {
                if (node.left == null && node.right == null)
                {
                    return node;
                }
                if (node.left == null && node == root)
                {
                    return node;
                }
                //if (node.left == null)
                //{
                //    return FirstSearchR(node.right);
                //}
                return FirstSearchR(node.left);
            }

            return FirstSearchR(root);
        }

        public TreeNode<K, V> LastEntry()
        {
            if (IsEmpty()) Empty();

            TreeNode<K, V> LastSearchR(TreeNode<K, V> node)
            {
                if (node.left == null && node.right == null)
                {
                    return node;
                }
                if (node.right == null && node == root)
                {
                    return node;
                }
                if (node.right == null)
                {
                    return LastSearchR(node.left);
                }
                return LastSearchR(node.right);
            }

            return LastSearchR(root);
        }

        public void Empty()
        {
            throw new Exception("Tree is empty");
        }

        public void OutRange()
        {
            throw new Exception("Index out of range");
        }

        public void SizesNotEquial()
        {
            throw new Exception("Objects' sizes aren't equial");
        }











    }
}
