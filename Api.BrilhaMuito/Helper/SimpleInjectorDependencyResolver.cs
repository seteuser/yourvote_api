using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Api.BrilhaMuito.Helper
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class SimpleInjectorDependencyResolver : IDependencyResolver
    {
        private readonly AsyncScopedLifestyle _scopedLifestyle = new AsyncScopedLifestyle();
        private readonly Container _container;
        private readonly DependencyResolverScopeOption _scopeOption;
        private readonly Scope _scope;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="container"></param>
        public SimpleInjectorDependencyResolver(Container container)
            : this(container, DependencyResolverScopeOption.UseAmbientScope)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="container"></param>
        /// <param name="scopeOption"></param>
        public SimpleInjectorDependencyResolver(Container container,
            DependencyResolverScopeOption scopeOption)
            : this(container, beginScope: false)
        {

            if (scopeOption < DependencyResolverScopeOption.UseAmbientScope ||
                scopeOption > DependencyResolverScopeOption.RequiresNew)
            {
                throw new System.ComponentModel.InvalidEnumArgumentException(nameof(scopeOption), (int)scopeOption,
                    typeof(DependencyResolverScopeOption));
            }

            _scopeOption = scopeOption;
        }

        private SimpleInjectorDependencyResolver(Container container, bool beginScope)
        {
            _container = container;
            if (beginScope)
            {
                _scope = AsyncScopedLifestyle.BeginScope(container);
            }
        }

        private IServiceProvider ServiceProvider => _container;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public void Dispose()
        {
            _scope?.Dispose();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public object GetService(Type serviceType)
        {
            if (!serviceType.IsAbstract && typeof(IHttpController).IsAssignableFrom(serviceType))
            {
                return _container.GetInstance(serviceType);
            }

            return ServiceProvider.GetService(serviceType);
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            var collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var services = (IEnumerable<object>)ServiceProvider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        public IDependencyScope BeginScope()
        {
            var beginScope = _scopeOption == DependencyResolverScopeOption.RequiresNew ||
                               _scopedLifestyle.GetCurrentScope(_container) == null;

            return new SimpleInjectorDependencyResolver(_container, beginScope);
        }
    }

    /// <summary>
    /// </summary>
    public enum DependencyResolverScopeOption
    {
        /// <summary>
        /// 
        /// </summary>
        UseAmbientScope,
        /// <summary>
        /// 
        /// </summary>
        RequiresNew
    }
}