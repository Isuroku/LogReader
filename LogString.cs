using System;
using System.Collections.Generic;
using System.Text;

namespace LogReader
{
    class CLogString
    {
        private List<Tuple<int, int>> _labels = new List<Tuple<int, int>>();
        private List<Tuple<int, int>> _strings = new List<Tuple<int, int>>();
        private List<int> _key_divs = new List<int>();

        string _line;
        int _line_num;

        public override string ToString()
        {
            return $"<{_line_num}> {_line}";
        }

        public int LineNumber { get { return _line_num; } }

        public string Text { get { return _line; } }

        public CLogString(string inLine, int inLineNum)
        {
            _line = inLine;
            _line_num = inLineNum;

            int StartIndex = FindSubstring(0, inLine, '[', ']', _labels);
            while(StartIndex > 0)
            {
                StartIndex++;
                StartIndex = FindSubstring(StartIndex, inLine, '[', ']', _labels);
            }

            StartIndex = FindSubstring(0, inLine, '\'', '\'', _strings);
            while (StartIndex > 0)
            {
                StartIndex++;
                StartIndex = FindSubstring(StartIndex, inLine, '\'', '\'', _strings);
            }

            StartIndex = FindKeyDiv(0, inLine, ':');
            while (StartIndex > 0)
            {
                StartIndex++;
                StartIndex = FindKeyDiv(StartIndex, inLine, ':');
            }
        }

        int FindKeyDiv(int inStartIndex, string inLine, char inDivChar)
        {
            int start_index = inLine.IndexOf(inDivChar, inStartIndex);
            if (start_index == -1)
                return -1;

            if (!InsidePair(start_index, _labels, ref start_index) && !InsidePair(start_index, _strings, ref start_index))
                _key_divs.Add(start_index);

            return start_index;
        }

        static bool InsidePair(int inStartIndex, List<Tuple<int, int>> ioPairs, ref int outLastIndex)
        {
            foreach(Tuple<int, int> t in ioPairs)
            {
                if (t.Item1 <= inStartIndex && t.Item2 >= inStartIndex)
                {
                    outLastIndex = t.Item2;
                    return true;
                }
            }
            return false;
        }

        static int FindSubstring(int inStartIndex, string inLine, char inOpenChar, char inCloseChar, List<Tuple<int, int>> ioPairs)
        {
            int start_index = inLine.IndexOf(inOpenChar, inStartIndex);
            if(start_index < 0)
            {
                return -1;
            }

            int end_index = inLine.IndexOf(inCloseChar, start_index + 1);
            if (end_index < 0)
            {
                return -1;
            }

            ioPairs.Add(new Tuple<int, int>(start_index, end_index));

            return end_index;
        }

        string[] _keys;

        internal string[] GetClearKeys()
        {
            if (_keys != null)
                return _keys;

            List<string> lst = new List<string>();

            int index = 0;
            int last_index = _line.Length - 1;

            while(index <= last_index)
            {
                if(!IsInsidePair(index, ref index))
                {
                    int next_div = GetNextKeyDiv(index);
                    string str = _line.Substring(index, next_div - index);
                    lst.Add(str);
                    index = next_div;
                }
                index++;
            }

            _keys = lst.ToArray();
            return _keys;
        }

        //bool IsLikeKey(int inStartIndex, int inLength)
        //{
        //    Char.
        //}

        int GetNextKeyDiv(int inIndex)
        {
            foreach(int div in _key_divs)
            {
                if (inIndex < div)
                    return div;
            }
            return _line.Length;
        }

        bool IsInsidePair(int inIndex, ref int outLastIndex)
        {
            if (InsidePair(inIndex, _labels, ref outLastIndex))
                return true;

            if (InsidePair(inIndex, _strings, ref outLastIndex))
                return true;

            return false;
        }
    }
}
