using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Category.BusinessObject
{
    public class Category
    {
        private int _CategoryID;
        public int CategoryID
        {
            get
            {
                try { return _CategoryID; }
                catch(Exception err) { throw new Exception("Error getting CategoryID", err); }
            }
            set
            {
                try { _CategoryID = value; }
                catch(Exception err) { throw new Exception("Error setting CategoryID",err); }
            }
        }
        private string _CategoryName;
        public string CategoryName
        {
            get
            {
                try { return _CategoryName; }
                catch (Exception err) { throw new Exception("Error getting CategoryName", err); }
            }
            set
            {
                try { _CategoryName = value; }
                catch (Exception err) { throw new Exception("Error setting CategoryName", err); }
            }
        }
        private int _ParentCategoryID;
        public int ParentCategoryID
        {
            get
            {
                try { return _ParentCategoryID; }
                catch (Exception err) { throw new Exception("Error getting ParentCategoryID", err); }
            }
            set
            {
                try { _ParentCategoryID = value; }
                catch (Exception err) { throw new Exception("Error setting ParentCategoryID", err); }
            }
        }
        private string _ParentCategory;
        public string ParentCategory
        {
            get
            {
                try { return _ParentCategory; }
                catch (Exception err) { throw new Exception("Error getting ParentCategory", err); }
            }
            set
            {
                try { _ParentCategory = value; }
                catch (Exception err) { throw new Exception("Error setting ParentCategory", err); }
            }
        }
        private int _ClientID;
        public int ClientID
        {
            get
            {
                try { return _ClientID; }
                catch (System.Exception err) { throw new Exception("Error getting ClientID", err); }
            }
            set
            {
                try { _ClientID = value; }
                catch (System.Exception err) { throw new Exception("Error gettting ClientID", err); }
            }
        }


        private int _CreatedBy;
        public int CreatedBy
        {
            get
            {
                try
                {
                    return _CreatedBy;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting CreatedBy", err);
                }
            }
            set
            {
                try
                {
                    _CreatedBy = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting CreatedBy", err);
                }
            }
        }

        private DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get
            {
                try
                {
                    return _CreatedOn;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting CreatedOn", err);
                }
            }
            set
            {
                try
                {
                    _CreatedOn = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting CreatedOn", err);
                }
            }
        }
        private DateTime _ModifiedOn;
        public DateTime ModifiedOn
        {
            get
            {
                try
                {
                    return _ModifiedOn;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting ModifiedOn", err);
                }
            }
            set
            {
                try
                {
                    _ModifiedOn = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting ModifiedOn", err);
                }
            }
        }
        private int _ModifiedBy;
        public int ModifiedBy
        {
            get
            {
                try
                {
                    return _ModifiedBy;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting ModifiedBy", err);
                }
            }
            set
            {
                try
                {
                    _ModifiedBy = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting ModifiedBy", err);
                }
            }
        }
        private int _ReferenceID;
        public int ReferenceID
        {
            get
            {
                try
                {
                    return _ReferenceID;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting ReferenceID", err);
                }
            }
            set
            {
                try
                {
                    _ReferenceID = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting ReferenceID", err);
                }
            }
        }
    }
    public class CategoryList : List<Category>
    { 
    }
}