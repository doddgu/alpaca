using Alpaca.Infrastructure.Caching;
using Alpaca.Infrastructure.Mapping.Interfaces;
using Alpaca.Infrastructure.Mapping.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpaca.Infrastructure.Mapping
{
    public class MapperWrapper<TModel, TEntity> : IRelationalMapping<TModel, TEntity>
        where TModel : class
        where TEntity : class
    {
        private static MemoryCache<Type, List<PropertyMapping>> _memoryCache = new MemoryCache<Type, List<PropertyMapping>>();

        private IMappingExpression<TModel, TEntity> _toEntityMappingExpression = null;
        private IMappingExpression<TEntity, TModel> _toModelMappingExpression = null;
        private IMapper _mapper = null;
        private Action<IMapperConfigurationExpression> MapperExpression = null;

        public List<Type> IgnoreMapperAttributeTypeList { get; set; }

        public MapperWrapper(List<Type> ignoreMapperAttributeTypeList = null)
        {
            this.IgnoreMapperAttributeTypeList = ignoreMapperAttributeTypeList;

            InitMapper();
        }

        public MapperWrapper(Action<IMapperConfigurationExpression> mapperExpression, List<Type> ignoreMapperAttributeTypeList = null)
        {
            this.IgnoreMapperAttributeTypeList = ignoreMapperAttributeTypeList;
            MapperExpression = mapperExpression;

            InitMapper();
        }

        private void InitMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                _toEntityMappingExpression = cfg.CreateMap<TModel, TEntity>();
                _toModelMappingExpression = cfg.CreateMap<TEntity, TModel>();

                MapperExpression?.Invoke(cfg);
            });

            _mapper = mapperConfiguration.CreateMapper();

            InitMapperByType(typeof(TModel));
            InitMapperByType(typeof(TEntity));
        }

        private void InitMapperByType(Type type)
        {
            var lstPropertyMapping = _memoryCache.GetOrAdd(type, (t) =>
            {
                var attributeType = typeof(MapperBaseAttribute);
                var properties = t.GetProperties().Where(x => x.IsDefined(attributeType, true));
                return properties.Select(x => new PropertyMapping(x, x.GetCustomAttributes(attributeType, false).FirstOrDefault() as MapperBaseAttribute)).ToList();
            });

            lstPropertyMapping.ForEach(p =>
            {
                var mapperAttribute = p.MapperAttribute as IMapperAttribute;
                if (mapperAttribute == null)
                {
                    throw new InvalidCastException("MapperAttribute must implement IMapperAttribute");
                }

                mapperAttribute.Apply(_toEntityMappingExpression, p.PropertyInfo.Name, this.IgnoreMapperAttributeTypeList, isToView: false);
                mapperAttribute.Apply(_toModelMappingExpression, p.PropertyInfo.Name, this.IgnoreMapperAttributeTypeList, isToView: true);
            });
        }

        public TEntity GetEntity(TModel model)
        {
            var entity = _mapper.Map<TModel, TEntity>(model);

            return entity;
        }

        public TEntity GetEntity(TModel model, TEntity destination)
        {
            var entity = _mapper.Map<TModel, TEntity>(model, destination);

            return entity;
        }

        public TModel GetModel(TEntity entity)
        {
            var dto = _mapper.Map<TEntity, TModel>(entity);

            return dto;
        }

        public List<TEntity> GetEntityList(List<TModel> lstModel)
        {
            var lstEntity = new List<TEntity>();

            lstModel.ForEach(dto =>
            {
                lstEntity.Add(_mapper.Map<TModel, TEntity>(dto));
            });

            return lstEntity;
        }

        public List<TModel> GetModelList(List<TEntity> lstEntity)
        {
            var lstDTO = new List<TModel>();

            lstEntity.ForEach(entity =>
            {
                lstDTO.Add(_mapper.Map<TEntity, TModel>(entity));
            });

            return lstDTO;
        }

    }
}
