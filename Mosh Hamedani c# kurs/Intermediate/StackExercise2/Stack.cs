using System;
using System.Collections.Generic;

namespace StackExercise2
{
    public class Stack
    {
        private readonly List<object> _list = new List<object>();
        public void Push(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException("We cannot push a null object into the stack");

            _list.Add(obj);
        }

        public object Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("The stack is empty");

            var index = _list.Count - 1;
            var toReturn = _list[index];

            _list.RemoveAt(index);

            return (toReturn);



        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}