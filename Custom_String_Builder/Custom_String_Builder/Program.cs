using System;
using System.Security.Claims;

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
        if(appendedText == null)
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
        while(capacity <  _chars.Length+insertedText.Length)
        {
            capacity *= 2;
        }

        int charsLennght = this.Length();

        Array.Resize(ref _chars, capacity);

        for ( int i = charsLennght-1; i >= index; i--)
        {
            _chars[i + insertedText.Length] = _chars[i];
        }
        for( int i = 0;i < insertedText.Length;i++ )
        {
            _chars[index + i] = insertedText[i];   
        }

        length += insertedText.Length;

        return this;
    }

    public StringBuilderAsDynamicArray RemoveDuplicates()
    {
        int tempIndex = 0;
        for(int i=0; i < _chars.Length;i++)
        {
            bool isDuplicate=true;
            for(int j=0; j < tempIndex;j++)
            {
                if (_chars[i] == _chars[j])
                {
                    isDuplicate = false; break;  
                }
            }
            if (isDuplicate)
            {
                _chars[tempIndex]= _chars[i];
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
            Console.WriteLine($"char[{i}] = \"{ _chars[i] }\"");
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
       length= tempIndex;
        Array.Resize(ref _chars, length);
        return this;
    }
    public string GetString() 
    {
        return new string(_chars, 0, _chars.Length);    
    }
    public bool IsBlank()
    {
        if (this._chars == null) return true;

        for (int i = 0; i < this._chars.Length; i++)
        {
            Console.WriteLine(this._chars[i]);
            if (!char.IsWhiteSpace(this._chars[i])) return false;
        }

        return true;
    }


    public string OnBlank( string text)
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


        //StringBuilderAsDynamicArray customSB = new StringBuilderAsDynamicArray();
        //customSB.InsertAt("   ", 0);
        // customSB.Append("   ");
        // Console.WriteLine("Is Blank: " + customSB.IsBlank());
        // Console.WriteLine(customSB.Length());
        // Console.WriteLine(customSB.GetString());
       //// Console.WriteLine( string.IsNullOrWhiteSpace(customSB.GetString()));

       // Console.WriteLine("On Blank: " + customSB.OnBlank("Default"));
    }
} 