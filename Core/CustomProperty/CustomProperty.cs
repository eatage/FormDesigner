using System;
using System.Reflection;

namespace FormDesinger
{
    /// <summary>
    /// 自定义属性
    /// </summary>
    public class CustomProperty
    {
        #region 私有属性
        private string _name = string.Empty;
        private object _defaultValue = null;
        private object _value = null;
        private object _objectSource = null;
        private PropertyInfo[] _propertyInfos = null;
        #endregion

        #region 构造方法
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        public CustomProperty()
        {
        }
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        /// <param name="name">显示名</param>
        /// <param name="category">类型名(分组)</param>
        /// <param name="description">描述</param>
        /// <param name="objectSource">控件源</param>
        public CustomProperty(string name, string category, string description, object objectSource)
            : this(name, name, null, category, description, objectSource, null)
        {
        }
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        /// <param name="name">显示名</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="category">类型名(分组)</param>
        /// <param name="description">描述</param>
        /// <param name="objectSource">控件源</param>
        public CustomProperty(string name, string propertyName, string category, string description, object objectSource)
            : this(name, propertyName, null, category, description, objectSource, null)
        {
        }
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        /// <param name="name">显示名</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="category">类型名(分组)</param>
        /// <param name="description">描述</param>
        /// <param name="objectSource">控件源</param>
        /// <param name="editorType">编辑器类型</param>
        public CustomProperty(string name, string propertyName, string category, string description, object objectSource, Type editorType)
            : this(name, propertyName, null, category, description, objectSource, editorType)
        {
        }
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        /// <param name="name">显示名</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="valueType">值类型</param>
        /// <param name="category">类型名(分组)</param>
        /// <param name="description">描述</param>
        /// <param name="objectSource">控件源</param>
        /// <param name="editorType">编辑器类型</param>
        public CustomProperty(string name, string propertyName, Type valueType, string category, string description,
            object objectSource, Type editorType)
            : this(name, new string[] { propertyName }, valueType, null, null, false, true, category, description, objectSource, editorType)
        {
        }
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        /// <param name="name">显示名</param>
        /// <param name="propertyNames">属性名</param>
        /// <param name="category">类型名(分组)</param>
        /// <param name="description">描述</param>
        /// <param name="objectSource">控件源</param>
        public CustomProperty(string name, string[] propertyNames, string category, string description, object objectSource)
            : this(name, propertyNames, category, description, objectSource, null)
        {
        }
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        /// <param name="name">显示名</param>
        /// <param name="propertyNames">属性名</param>
        /// <param name="category">类型名(分组)</param>
        /// <param name="description">描述</param>
        /// <param name="objectSource">控件源</param>
        /// <param name="editorType">编辑器类型</param>
        public CustomProperty(string name, string[] propertyNames, string category, string description, object objectSource, Type editorType)
            : this(name, propertyNames, null, category, description, objectSource, editorType)
        {
        }
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        /// <param name="name">显示名</param>
        /// <param name="propertyNames">属性名</param>
        /// <param name="valueType">值类型</param>
        /// <param name="category">类型名(分组)</param>
        /// <param name="description">描述</param>
        /// <param name="objectSource">控件源</param>
        /// <param name="editorType">编辑器类型</param>
        public CustomProperty(string name, string[] propertyNames, Type valueType, string category, string description,
            object objectSource, Type editorType)
            : this(name, propertyNames, valueType, null, null, false, true, category, description, objectSource, editorType)
        {
        }
        /// <summary>
        /// 自定义属性显示
        /// </summary>
        /// <param name="name">显示名</param>
        /// <param name="propertyNames">属性名</param>
        /// <param name="valueType">值类型</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="value">值</param>
        /// <param name="isReadOnly">是否只读</param>
        /// <param name="isBrowsable">是否在设计器显示</param>
        /// <param name="category">类型名(分组)</param>
        /// <param name="description">描述</param>
        /// <param name="objectSource">控件源</param>
        /// <param name="editorType">编辑器类型</param>
        public CustomProperty(string name, string[] propertyNames, Type valueType, object defaultValue, object value,
            bool isReadOnly, bool isBrowsable, string category, string description, object objectSource, Type editorType)
        {
            Name = name;
            PropertyNames = propertyNames;
            ValueType = valueType;
            _defaultValue = defaultValue;
            _value = value;
            IsReadOnly = isReadOnly;
            IsBrowsable = isBrowsable;
            Category = category;
            Description = description;
            ObjectSource = objectSource;
            EditorType = editorType;
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 显示名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                if (PropertyNames == null)
                {
                    PropertyNames = new string[] { _name };
                }
            }
        }
        /// <summary>
        /// 属性名
        /// </summary>
        public string[] PropertyNames { get; set; }
        /// <summary>
        /// 值类型
        /// </summary>
        public Type ValueType { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public object DefaultValue
        {
            get { return _defaultValue; }
            set
            {
                _defaultValue = value;
                if (_defaultValue != null)
                {
                    if (_value == null) _value = _defaultValue;
                    if (ValueType == null) ValueType = _defaultValue.GetType();
                }
            }
        }
        /// <summary>
        /// 值
        /// </summary>
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;

                OnValueChanged();
            }
        }
        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 类型名(分组)
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 是否在设计器显示
        /// </summary>
        public bool IsBrowsable { get; set; }
        /// <summary>
        /// 控件源
        /// </summary>
        public object ObjectSource
        {
            get { return _objectSource; }
            set
            {
                _objectSource = value;
                OnObjectSourceChanged();
            }
        }
        /// <summary>
        /// 编辑器类型
        /// </summary>
        public Type EditorType { get; set; }
        #endregion

        #region 保护方法

        protected void OnObjectSourceChanged()
        {
            if (PropertyInfos.Length == 0) return;

            object value = PropertyInfos[0].GetValue(_objectSource, null);
            if (_defaultValue == null) DefaultValue = value;
            _value = value;
        }

        protected void OnValueChanged()
        {
            if (_objectSource == null) return;

            foreach (PropertyInfo propertyInfo in PropertyInfos)
            {
                propertyInfo.SetValue(_objectSource, _value, null);
            }
        }

        protected PropertyInfo[] PropertyInfos
        {
            get
            {
                if (_propertyInfos == null)
                {
                    Type type = ObjectSource.GetType();
                    _propertyInfos = new PropertyInfo[PropertyNames.Length];
                    for (int i = 0; i < PropertyNames.Length; i++)
                    {
                        _propertyInfos[i] = type.GetProperty(PropertyNames[i]);
                    }
                }
                return _propertyInfos;
            }
        }
        #endregion

        #region 公有方法
        public void ResetValue()
        {
            Value = DefaultValue;
        }
        #endregion
    }
}