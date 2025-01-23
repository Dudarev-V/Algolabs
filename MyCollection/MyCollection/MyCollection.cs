using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public interface IMyCollection<T>
    {
        void Add(T e);
        void AddAll(T[] a);
        void Clear();
        bool Contains(object o);
        bool ContainsAll(IMyCollection<T> c);
        bool IsEmpty();
        void Remove(object o);
        void RemoveAll(IMyCollection<T> c);
        void RetainAll(IMyCollection<T> c);
        int Size();
        T[] ToArray();
        T[] ToArray(T[] a);
    }

    public interface IMyList<T> : IMyCollection<T>
    {
        void Add(int index, T e);
        void AddAll(int index, IMyCollection<T> c);
        T Get(int index);
        int IndexOf(object o);
        int LastIndexOf(object o);
        void ListIterator();
        void ListIterator(int index);
        void Remove(int index);
        void Set(int index, T e);
        T[] SubList(int fromindex, int toindex);
    }

    public interface IMyQueue<T> : IMyCollection<T>
    {
        T Element();
        bool Offer(T obj);
        T Peek();
        T Poll();
    }

    public interface IMyDeque<T> : IMyCollection<T>
    {
        void AddFirst(T obj);
        void AddLast(T obj);
        T GetFirst();
        T GetLast();
        bool OfferFirst(T obj);
        bool OfferLast(T obj);
        T Pop();
        void Push(T obj);
        T PeekFirst();
        T PeekLast();
        T PollFirst();
        T PollLast();
        void RemoveLast();
        void RemoveFirst();
        bool RemoveLastOccurance(object obj);
        bool RemoveFirstOccurance(object obj);
    }

    public interface IMySet<T> : IMyCollection<T>
    {
        T First();
        T Last();
        T[] SubSet(T fromElement, T toElement);
        T[] HeadSet(T toElement);
        T[] TailSet(T fromElement);
    }

    public interface IMySortedSet<T> : IMySet<T> //Скрывать?
    {
        new T First();
        new T Last();
        new T[] SubSet(T fromElement, T toElement);
        new T[] HeadSet(T toElement);
        new T[] TailSet(T fromElement);
    }

    public interface MyNavigableSet<T> : IMySortedSet<T>
    {
        T LowerEntry(T key);
        T FloorEntry(T key);
        T HigherEntry(T key);
        T CeilngEntry(T key);
        T LowerKey(T key);
        T FloorKey(T key);
        T HigherKey(T key);
        T CeilingKey(T key);
        T PollFirstEntry();
        T PollLastEntry();
        T FirstEntry();
        T LastEntry();
    }

    public interface IMyMap<K, V>
    {
        void Clear();
        bool ContainsKey(object key);
        bool ContainsValue(object value);
        MyVector.MyVector<MyHashMap.Entry<K, V>> EntrySet();
        V Get(object key);
        bool IsEmpty();
        K[] KeySet();
        void Put(K key, V value);
        void PutAll(IMyMap<K, V> m); //***********
        void Remove(object key);
        int Size();
        V[] Values();
    }

    public interface IMySortedMap<K, V> : IMyMap<K, V>
    {
        K FirstKey();
        K LastKey();
        K[] HeadMap(K end); //?
        K[] SubMap(K start, K end); //?
        K[] TailMap(K start); //?
    }

    public interface IMyNavigableMap<K, V> : IMySortedMap<K, V>
    {
        MyHashMap.Entry<K, V> LowerEntry(K key); //?
        MyHashMap.Entry<K, V> FloorEntry(K key); //?
        MyHashMap.Entry<K, V> HigherEntry(K key); //?
        MyHashMap.Entry<K, V> CeilingEntry(K key); //?
        K LowerKey(K key);
        K FloorKey(K key);
        K HigherKey(K key);
        K CeilingKey(K key);
        MyTreeMap.TreeNode<K, V> PollFirstEntry(); //?
        MyTreeMap.TreeNode<K, V> PollLastEntry(); //?
        MyTreeMap.TreeNode<K, V> FirstEntry(); //?
        MyTreeMap.TreeNode<K, V> LastEntry(); //?
    }

    public interface IExceptions
    {
        void Empty();
        void OutRange();
        void SizesNotEquial();

    }

    public interface IMyIterator<T>
    {
        bool HasNext();
        T Next();
        void Remove();
    }

    public interface IMyListIterator<T>
    {
        bool HasNext();
        bool HasPrevious();
        T Previous();
        int NextIndex();
        int PreviousIndex();
        T Next();
        void Set(T element);
        void Add(T element);
        void Remove();
    }
}
