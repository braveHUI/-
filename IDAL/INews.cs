﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface INews
    {
        IEnumerable<News> FindAllNews();
        IEnumerable<News> FindCountryNews();
        IEnumerable<News> FindInternationalNews();
        IEnumerable<News> FindHotNews();
        News FindDetailNews(int id);
        News FindPreNews(int id);
        News FindNextNews(int id);

        IEnumerable<News> FindClassifyNews();
        IList<News> SelectNews(string keyword);
                 
    }
}
