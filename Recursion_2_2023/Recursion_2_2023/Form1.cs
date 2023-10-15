using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recursion_2_2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class OneWayList
        {
            public List<OneWayListElement> list;
            public int Count;

            public OneWayList()
            {
                list = new List<OneWayListElement>();
                Count = list.Count;
            }

            public void add(OneWayListElement el)
            {
                list.Add(el);
                if(list.Count > 1)
                {
                    list[list.Count - 2].next = list[list.Count - 1];
                }
                Count++;
            }

            public OneWayListElement findLast()
            {
                return search(0, null);
            }

            private OneWayListElement search(int position, OneWayListElement param)
            {
                if(position == list.Count)
                {
                    return null;
                }
                if(list[position].next != param)
                {
                    return search(position + 1, param);
                }
                else
                {
                    return list[position];
                }
            }

            public OneWayListElement findFirst()
            {
                return searchFirst(0);
            }

            private OneWayListElement searchFirst(int position)
            {
                if(search(0, list[position]) != null)
                {
                    return searchFirst(position + 1);
                }
                else
                {
                    return list[position];
                }
            }

            public OneWayListElement findPrevious(OneWayListElement param)
            {
                return search(0, param);
            }
        }

        public class OneWayListElement
        {
            public int value;
            public OneWayListElement next;
            
            public OneWayListElement(int val)
            {
                value = val;
                next = null;
            }
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            OneWayList list = new OneWayList();
            if (numericUpDownLimit.Value != 0)
            {
                list = fill(Convert.ToInt32(numericUpDownLimit.Value), list);
            }
            list = shuffle(list, 0);
            textBoxOut.Text = "[" + show("", list.findFirst()) + "]";
        }

        public OneWayList fill(int limit, OneWayList list)
        {
            if (limit != list.list.Count)
            {
                list.add(new OneWayListElement(list.Count + 1));
                list = fill(limit, list);
            }
            return list;
        }

        public OneWayList shuffle(OneWayList list, int position)
        {
            switch (list.Count - position)
            {
                case 0: break;
                case 1: break;
                default:
                    OneWayListElement temp = list.list[position].next;
                    list.list[position].next = list.list[position].next.next;
                    temp.next = list.list[position];
                    if(position != 0)
                    {
                        list.findPrevious(list.list[position]).next = temp;
                    }
                    list = shuffle(list, position + 2);
                    break;
            }
            return list;
        }

        public string show(string line, OneWayListElement el)
        {
            line += el.value;
            if(el.next != null)
            {
                line += ", ";
                line += show("", el.next);
            }
            return line;
        }
    }
}
