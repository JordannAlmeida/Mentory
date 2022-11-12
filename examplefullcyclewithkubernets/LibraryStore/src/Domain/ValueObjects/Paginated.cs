using System;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class Paginated<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalItens { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Itens { get; set; }

        protected Paginated()
        {
            Itens = new List<T>();
        }

        public Paginated(int pageNumber, int pageSize, int totalItens, int totalPages, IEnumerable<T> itens)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItens = totalItens;
            TotalPages = totalPages;
            Itens = itens;
        }

        public Paginated(int pageNumber, int pageSize, int totalItens, IEnumerable<T> itens)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItens = totalItens;
            TotalPages = (int)Math.Ceiling(decimal.Divide(TotalItens, (PageSize > 0 ? PageSize : TotalItens)));
            Itens = itens;
        }
    }
}