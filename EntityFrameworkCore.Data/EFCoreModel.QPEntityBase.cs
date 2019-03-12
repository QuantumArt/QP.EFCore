// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EFCore.Models;

namespace EntityFrameworkCore.Data
{

    public abstract class QPLinkBase
    {

        private bool _insertWithArticle = false;
        public bool InsertWithArticle
        {
            get
            {
                return _insertWithArticle;
            }
            set
            {
                _insertWithArticle = value;
            }
        }
        
        private bool _removeWithArticle = false;
        public bool RemoveWithArticle
        {
            get
            {
                return _removeWithArticle;
            }
            set
            {
                _removeWithArticle = value;
            }
        }	
        
        private string _insertingInstruction;
        public string InsertingInstruction
        {
            get
            {
                if (String.IsNullOrEmpty(_insertingInstruction))
                    SaveInsertingInstruction();
                return _insertingInstruction;
            }
        }
        
        
        private string _removingInstruction;
        public string RemovingInstruction
        {
            get
            {
                if (String.IsNullOrEmpty(_removingInstruction))
                    SaveRemovingInstruction();
                return _removingInstruction;
            }
        }
        
        public void SaveRemovingInstruction()
        {
            _removingInstruction = String.Format("EXEC sp_executesql N'EXEC qp_delete_single_link @linkId, @itemId, @linkedItemId', N'@linkId NUMERIC, @itemId NUMERIC, @linkedItemId NUMERIC', @linkId = {0}, @itemId = {1}, @linkedItemId = {2}", this.LinkId, this.Id, this.LinkedItemId);
        }
        
        public void SaveInsertingInstruction()
        {
            _insertingInstruction = String.Format("EXEC sp_executesql N'EXEC qp_insert_single_link @linkId, @itemId, @linkedItemId', N'@linkId NUMERIC, @itemId NUMERIC, @linkedItemId NUMERIC', @linkId = {0}, @itemId = {1}, @linkedItemId = {2}", this.LinkId, this.Id, this.LinkedItemId);
        }
        
        public abstract int LinkId { get; }
        public abstract int Id { get; }
        public abstract int LinkedItemId { get; }
    
    }
}
