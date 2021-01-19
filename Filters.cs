using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogReader
{
    public interface IFilter
    {
        bool Access(string inLine);
        void SetInvert(bool v);
    }

    class CTextFilter: IFilter
    {
        string _key;
        bool _invert;

        public CTextFilter(string key)
        {
            _key = key;
        }

        public override string ToString()
        {
            if(_invert)
                return $"!{_key}";
            return $"{_key}";
        }

        public void SetInvert(bool v)
        {
            _invert = v;
        }

        public bool Access(string inLine)
        {
            bool res = inLine.Contains(_key);
            return _invert ? !res : res;
        }
    }

    class CFilters : IFilter
    {
        List<IFilter> _filters = new List<IFilter>();
        bool _and;
        bool _invert;

        public CFilters(bool inAnd)
        {
            _and = inAnd;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_invert)
                sb.Append("!");
            sb.Append("(");

            sb.Append(_filters[0].ToString());

            for (int i = 1; i < _filters.Count; i++)
            {
                if(_and)
                    sb.Append(" && ");
                else
                    sb.Append(" || ");

                sb.Append(_filters[i].ToString());
            }

            sb.Append(")");
            return sb.ToString();
        }

        public void AddFilter(IFilter f)
        {
            _filters.Add(f);
        }

        public bool Access(string inLine)
        {
            bool stop = false;
            for(int i = 0; i < _filters.Count && !stop; i++)
            {
                bool res = _filters[i].Access(inLine);
                stop = _and && !res || !_and && res; //_and && !res - fail; !_and && res - ok
            }

            bool all_res = _and ? !stop : stop;
            all_res = _invert ? !all_res : all_res;
            return all_res;
        }

        public void SetInvert(bool v)
        {
            _invert = v;
        }
    }

    static class CFilterFactory
    {
        enum ELexems { Worlds, OpenBracer, OpenBracerNot, CloseBracer, And, Or }

        static Tuple<string, ELexems>[] LexStrings =
        {
            new Tuple<string, ELexems>("(", ELexems.OpenBracer),
            new Tuple<string, ELexems>("!(", ELexems.OpenBracerNot),
            new Tuple<string, ELexems>(")", ELexems.CloseBracer),
            new Tuple<string, ELexems>("&&", ELexems.And),
            new Tuple<string, ELexems>("||", ELexems.Or),
        };

        public static IFilter Create(string inLine)
        {
            List<Tuple<ELexems, int, int>> lexems = new List<Tuple<ELexems, int, int>>();
            CollectLexems(inLine, lexems);

            IFilter f = CreateOr(inLine, lexems, ELexems.Or, 0, lexems.Count);

            return f;
        }

        private static IFilter CreateOr(string inLine, List<Tuple<ELexems, int, int>> lexems, ELexems inOrAndLex, int start, int end)
        {
            IFilter f = null;
            int deep = 0;
            int mem_start = start;
            for (int i = start; i < end; i++)
            {
                ELexems lex = lexems[i].Item1;
                if (lex == ELexems.OpenBracer || lex == ELexems.OpenBracerNot)
                {
                    deep++;
                }
                else if (lex == ELexems.CloseBracer)
                {
                    deep--;
                }
                else if (deep == 0 && lex == inOrAndLex)
                {
                    if (f == null)
                        f = new CFilters(inOrAndLex == ELexems.And);

                    IFilter sf = CreateNew(inLine, lexems, inOrAndLex, mem_start, i);
                    if (sf != null)
                    {
                        (f as CFilters)?.AddFilter(sf);
                    }

                    mem_start = i + 1;
                }
            }

            if (mem_start < end)
            {
                IFilter sf = CreateNew(inLine, lexems, inOrAndLex, mem_start, end);
                if (sf != null)
                {
                    if (f != null)
                    {
                        (f as CFilters)?.AddFilter(sf);
                    }
                    else
                        f = sf;
                }
            }

            return f;
        }

        private static IFilter CreateNew(string inLine, List<Tuple<ELexems, int, int>> lexems, ELexems inOrAndLex, int start, int end)
        {
            IFilter f = null;
            if (end - start == 1 && lexems[start].Item1 == ELexems.Worlds)
            {
                f = CreateWorld(inLine, lexems, start);
            }
            else if (IsBraceEnvelop(inLine, lexems, start, end))
            {
                f = CreateOr(inLine, lexems, ELexems.Or, start + 1, end - 1);
                if(f != null)
                    f.SetInvert(lexems[start].Item1 == ELexems.OpenBracerNot);
            }
            else if (inOrAndLex == ELexems.Or)
            {
                f = CreateOr(inLine, lexems, ELexems.And, start, end);
            }

            ///!!!!!!!!!!!!!!!!!!
            return f;
        }

        private static bool IsBraceEnvelop(string inLine, List<Tuple<ELexems, int, int>> lexems, int start, int end)
        {
            ELexems first_lex = lexems[start].Item1;
            ELexems end_lex = lexems[end - 1].Item1;
            bool left = first_lex == ELexems.OpenBracer || first_lex == ELexems.OpenBracerNot;
            bool right = end_lex == ELexems.CloseBracer;
            if (!left || !right)
            {
                return false;
            }

            int deep = 0;
            int deep_0_brace_count = 0;
            for (int i = start; i < end; i++)
            {
                ELexems lex = lexems[i].Item1;
                if (lex == ELexems.OpenBracer || lex == ELexems.OpenBracerNot)
                {
                    deep++;
                }
                else if (lex == ELexems.CloseBracer)
                {
                    deep--;
                    if (deep == 0)
                        deep_0_brace_count++;
                }
            }
            return deep_0_brace_count == 1;
        }


        private static CTextFilter CreateWorld(string inLine, List<Tuple<ELexems, int, int>> lexems, int start)
        {
            int len = lexems[start].Item3 - lexems[start].Item2;
            string str = inLine.Substring(lexems[start].Item2, len);
            CTextFilter f = new CTextFilter(str.Trim());
            return f;
        }

        static void CollectLexems(string inLine, List<Tuple<ELexems, int, int>> lexems)
        {
            int i = 0;
            while (i < inLine.Length)
            {
                int start_lex;
                int end_lex;
                ELexems lex = FindFirstLexem(inLine, i, out start_lex, out end_lex);

                if (i < start_lex)
                {
                    AddLexem(inLine, lexems, ELexems.Worlds, i, start_lex);
                }

                AddLexem(inLine, lexems, lex, start_lex, end_lex);
                i = end_lex;
            }
        }

        static void AddLexem(string inLine, List<Tuple<ELexems, int, int>> lexems, ELexems lex, int start_lex, int end_lex)
        {
            if(lex == ELexems.Worlds)
            {
                bool find_char = false;

                for (int i = start_lex; i < end_lex && !find_char; i++)
                    find_char = inLine[i] != ' ';

                if (!find_char)
                    return;
            }
            lexems.Add(new Tuple<ELexems, int, int>(lex, start_lex, end_lex));
        }

        static ELexems FindFirstLexem(string inLine, int start, out int start_lex, out int end_lex)
        {
            ELexems lex = ELexems.Worlds;
            start_lex = inLine.Length;
            end_lex = start_lex;
            for (int i = 0; i < LexStrings.Length; i++)
            {
                int pos = inLine.IndexOf(LexStrings[i].Item1, start);
                if(pos != -1 && pos < start_lex)
                {
                    start_lex = pos;
                    end_lex = start_lex + LexStrings[i].Item1.Length;
                    lex = LexStrings[i].Item2;
                }
            }

            if(lex == ELexems.Worlds)
            {
                start_lex = start;
            }
            return lex;
        }
    }
}
