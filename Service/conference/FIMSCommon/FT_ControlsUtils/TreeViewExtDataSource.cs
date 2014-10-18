using System.Collections.Generic;

namespace FT_ControlsUtils
{
    public class TreeViewExtDataSource<TEntity, TRelation>
    {
        private DBBuilder _builder = new DBBuilder();
        private IList<TEntity> _entityTree;
        private string _oldRelationOwner;
        private IList<TRelation> _oldRelationTree;

        public TreeViewExtDataSource()
        {
            _entityTree = new List<TEntity>();
            _oldRelationTree = new List<TRelation>();
        }

        public IList<TEntity> GetEntities()
        {
            return _entityTree;
        }

        public void SetEntities(IList<TEntity> entities)
        {
            _entityTree = entities;
        }

        public IList<TRelation> GetOldRelations()
        {
            return _oldRelationTree;
        }

        public void SetOldRelations(IList<TRelation> oldRelation)
        {
            _oldRelationTree = oldRelation;
        }

        public void AddEntity(TEntity obj)
        {
            _entityTree.Add(obj);
        }

        public void DeleteEntity(TEntity obj)
        {
            _entityTree.Remove(obj);
        }

        public void ModifyEntity(TEntity oldObj, TEntity newObj)
        {
            _entityTree.Remove(oldObj);
            _entityTree.Add(newObj);
        }

        internal string GetOldRelationOwner()
        {
            return _oldRelationOwner;
        }

        internal void SetOldRelationOwner(string owner)
        {
            _oldRelationOwner = owner;
        }
    }
}