using System;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CustomStringBuilder
{
    public class StringBuilderAsDynamicArray
    {
        private char[] _chars;
        private int capacity;
        private int length;
        public StringBuilderAsDynamicArray()
        {
            this._chars = new char[0];
            capacity = 2;
            length = 0;
        }
        public int Length()
        {
            return length;
        }
        public int Capacity()
        {
            return capacity;
        }

        private void _charsResizing(int size)
        {
            while (capacity < length + size)
            {
                capacity *= 2;

            }
            var tmpBuffer = new char[capacity];
            for (int i = 0; i < _chars.Length; i++)
            {
                tmpBuffer[i] = _chars[i];

            }
            _chars = tmpBuffer;
            // Array.Resize(ref _chars, capacity);
        }
        public StringBuilderAsDynamicArray Append(string appendedText)
        {
            if (appendedText == null)
            {
                return this;
            }

            this._charsResizing(appendedText.Length);


            for (int i = 0; i < appendedText.Length; i++)
            {
                _chars[length] = appendedText[i];
                length++;
            }
            return this;

        }

        public StringBuilderAsDynamicArray InsertAt(String insertedText, int index)
        {
            if (insertedText == null || index < 0 || index > _chars.Length)
            {
                return this;
            }
            while (capacity < _chars.Length + insertedText.Length)
            {
                capacity *= 2;
            }

            int charsLennght = this.Length();

            Array.Resize(ref _chars, capacity);

            for (int i = charsLennght - 1; i >= index; i--)
            {
                _chars[i + insertedText.Length] = _chars[i];
            }
            for (int i = 0; i < insertedText.Length; i++)
            {
                _chars[index + i] = insertedText[i];
            }

            length += insertedText.Length;

            return this;
        }

        public StringBuilderAsDynamicArray RemoveDuplicates()
        {
            int tempIndex = 0;
            for (int i = 0; i < _chars.Length; i++)
            {
                bool isDuplicate = true;
                for (int j = 0; j < tempIndex; j++)
                {
                    if (_chars[i] == _chars[j])
                    {
                        isDuplicate = false; break;
                    }
                }
                if (isDuplicate)
                {
                    _chars[tempIndex] = _chars[i];
                    tempIndex++;
                }

            }
            while (capacity / 2 >= tempIndex)
            {
                capacity /= 2;
            }
            length = tempIndex;
            Array.Resize(ref _chars, length);
            return this;
        }

        public StringBuilderAsDynamicArray RemoveWhitespaces()
        {
            int tempIndex = 0;
            char Whitespace = ' ';
            Console.WriteLine(this.GetString() + this.Length());
            for (int i = 0; i < _chars.Length; i++)
            {
                Console.WriteLine("100");
                Console.WriteLine($"char[{i}] = \"{_chars[i]}\"");
                if (_chars[i] != Whitespace)
                {
                    Console.WriteLine("103");
                    _chars[tempIndex] = _chars[i];
                    tempIndex++;
                }
            }

            if (tempIndex == 0)
            {
                Console.WriteLine("111");
                //return null;       // harcnel  ??                                        
                return new StringBuilderAsDynamicArray();
            }
            while (capacity / 2 >= tempIndex)
            {
                capacity /= 2;
            }
            length = tempIndex;
            Array.Resize(ref _chars, length);
            return this;
        }
        public string GetString()
        {
            return new string(_chars);
        }
        public bool IsBlank()
        {
            if (this._chars == null) return true;

            for (int i = 0; i < this._chars.Length; i++)
            {
                // Console.WriteLine(this._chars[i]);
                if (!char.IsWhiteSpace(this._chars[i])) return false;
            }

            return true;
        }
        public string OnBlank(string text)
        {
            if (!this.IsBlank())
            {
                return this.GetString();
            }
            else
            {
                return text;
            }
        }
    }


    public class StringBuilderAsLinkedList
    {
        private class Node
        {
            public char[] _chars;
            public Node next;
            public int nodeLength;


            public Node(char[] text)
            {
                _chars = text;
                nodeLength = text.Length;
                next = null;
            }
        }
        private Node head;
        private Node tail;

        public StringBuilderAsLinkedList()
        {
            head = null;
            tail = null;
        }
        public int Length()
        {
            int length = 0;
            Node tempNode = head;
            while (tempNode != null)
            {
                length += tempNode.nodeLength;
                tempNode = tempNode.next;
            }
            return length;
        }
        public StringBuilderAsLinkedList Append(string appendedText)
        {
            if (appendedText == null) return this;

            Node appendedNode = new Node(appendedText.ToCharArray());
            if (head == null)
            {
                head = appendedNode;
                tail = head;
            }
            else
            {
                tail.next = appendedNode;
                tail = tail.next;
            }

            return this;

        }
        public StringBuilderAsLinkedList InsertAt(string insertedText, int index)
        {
            if (insertedText == null || index < 0 || index > this.Length())
            {
                return this;
            }
            Node cangingNode = null;
            Node tempNode = head;
            int tempLength = 0;
            do
            {
                tempLength += tempNode.nodeLength;
                cangingNode = tempNode;
                tempNode = tempNode.next;
            }

            while (tempLength < index);

            int tempIndex = index - (tempLength - cangingNode.nodeLength);

            int j = 0;
            Char[] resChars = new Char[cangingNode.nodeLength + index];

            for (int i = 0; i < tempIndex; i++)
            {

                resChars[j] = cangingNode._chars[i];
                j++;
            }
            for (int i = 0; i < insertedText.Length; i++)
            {

                resChars[j] = (insertedText[i]);
                j++;

            }
            for (int i = tempIndex; i < cangingNode.nodeLength; i++)
            {

                resChars[j] = (cangingNode._chars[i]);
                j++;
            }
            cangingNode._chars = resChars;
            cangingNode.nodeLength = resChars.Length;
            return this;

        }
        public string GetString()
        {
            Char[] resChar = new char[this.Length()];
            Node tempNod = head;
            int i = 0;
            while (tempNod != null)
            {
                foreach (char c in tempNod._chars)
                {
                    resChar[i] = c;
                    i++;
                }
                tempNod = tempNod.next;
            }
            return new string(resChar);
        }
        public StringBuilderAsLinkedList RemoveDuplicates()
        {
            if (head == null) return this;
            Char[] tempChar = this.GetString().ToCharArray();

            int tempIndex = 0;
            for (int i = 0; i < tempChar.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < tempIndex; j++)
                {
                    if (tempChar[i] == tempChar[j])
                    {
                        isDuplicate = true; break;
                    }
                }
                if (!isDuplicate)
                {
                    tempChar[tempIndex] = tempChar[i];
                    tempIndex++;
                }
            }

            Array.Resize(ref tempChar, tempIndex);

            Node tempNod = new Node(tempChar);
          
            this.head = tempNod ;
            this.tail = tempNod ;
            return this;

        }
        public StringBuilderAsLinkedList RemoveWhitespaces()
        {
            if (head == null) return this;
            Node tempNode = head;
            while (tempNode != null)
            {
                Char[] newCars = new char[tempNode.nodeLength];
                int length = 0;
                foreach (char c in tempNode._chars)
                {
                    if (!Char.IsWhiteSpace(c))
                    {
                        newCars[length] = (c);
                        length++;
                    }
                }
                Array.Resize<char>(ref newCars, length);
                tempNode._chars = newCars;
                tempNode.nodeLength = length;
                tempNode = tempNode.next;
            }
            return this;
        }
        public bool IsBlank()
        {
            if (this.head == null) return true;
            Char[] tempChar = this.GetString().ToCharArray();

            for (int i = 0; i < tempChar.Length; i++)
            {
                if (!char.IsWhiteSpace(tempChar[i])) return false;
            }

            return true;
        }
        public string OnBlank(string text)
        {
            if (!this.IsBlank())
            {
                return this.GetString();
            }
            else
            {
                return text;
            }
        }

    }


    public class Program
    {
        public static void Main()
        {
            //StringBuilderAsDynamicArray customSB = new StringBuilderAsDynamicArray();
            //Console.WriteLine(customSB.Length());
            //customSB.Append(" 1");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length()+" "+customSB.Capacity());
            //customSB.Append(" 2");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity());
            //customSB.Append(" 3");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity());
            //customSB.Append(" 4");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity() );
            //customSB.Append(" 5");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity());
            //customSB.Append(" 6");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity());
            //customSB.Append(" 7");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity());
            //customSB.Append(" 8");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity());
            //customSB.Append(" 9");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity());
            //customSB.Append(" 10");
            //Console.WriteLine(customSB.GetString());
            //Console.WriteLine(customSB.Length() + " " + customSB.Capacity());


            //StringBuilderAsDynamicArray customSB = new StringBuilderAsDynamicArray();
            //customSB.Append("Hello, ").Append("how ").Append("are ").Append("you?");
            //customSB.InsertAt("Hey!  ", 0);

            //Console.WriteLine("Length: " + customSB.Length());
            //Console.WriteLine("Original String: " + customSB.GetString());

            //customSB.RemoveDuplicates();
            //Console.WriteLine("After Removing Duplicates: " + customSB.GetString());

            //customSB.RemoveWhitespaces();
            //Console.WriteLine("After Removing Whitespaces: " + customSB.GetString());


            //string s = "   ";
            //char[] c = { ' ', ' ', ' ' };

            //string s1 = new string(c);
            //Console.WriteLine(string.IsNullOrWhiteSpace(s));
            //Console.WriteLine(string.IsNullOrWhiteSpace(s1));


            //Console.WriteLine(s == s1);
            //// StringBuilderAsDynamicArray customSB = new StringBuilderAsDynamicArray();
            // customSB.InsertAt(" ", 0);
            //// customSB.Append("   ");
            //// Console.WriteLine("Length return ->" +customSB.Length());
            //// Console.WriteLine("get string return ->" +customSB.GetString());
            //// Console.WriteLine("Is Blank: " + customSB.IsBlank());

            // Console.WriteLine(string.IsNullOrWhiteSpace(customSB.GetString()));

            // StringBuilder sbObj = new StringBuilder();

            //Console.WriteLine("On Blank: " + customSB.OnBlank("Default"));

            StringBuilderAsLinkedList SB_obj = new StringBuilderAsLinkedList();
            //   Console.WriteLine( SB_obj.GetString());
            SB_obj.Append("helloWorld");
            Console.WriteLine(SB_obj.GetString());
            Console.WriteLine(SB_obj.Length());
            SB_obj.Append("helloWorld");
            Console.WriteLine(SB_obj.GetString());
            Console.WriteLine(SB_obj.Length());
            SB_obj.InsertAt("  ", 5);
            SB_obj.InsertAt("   ", 23);
            Console.WriteLine(SB_obj.GetString());
            Console.WriteLine(SB_obj.Length());

            SB_obj.RemoveDuplicates();
            Console.WriteLine(SB_obj.GetString());
            Console.WriteLine(SB_obj.Length());
            SB_obj.RemoveWhitespaces();
            Console.WriteLine(SB_obj.GetString());
            Console.WriteLine(SB_obj.Length());


        }
    }
}
