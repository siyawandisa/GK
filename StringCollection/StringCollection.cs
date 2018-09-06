using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GlobalKinetics
{    
    public class StringCollection: IStringCollection
    {
        private List<string> strings;

        public StringCollection(){
            strings = new List<string>();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddString(string s){
            if (string.IsNullOrEmpty(s))
                throw new Exception("Please provide a valid string");
                
            strings.Add(s);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public override string ToString(){
            return string.Join(", ", strings);
        }
    }

    public interface IStringCollection
    {
        void AddString(string s);
        string ToString();
    }

}