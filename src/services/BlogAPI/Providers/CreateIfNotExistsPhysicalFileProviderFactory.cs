using System.IO;

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;

namespace BlogAPI.Providers
{
    public static class CreateIfNotExistsPhysicalFileProviderFactory
    {
        public static PhysicalFileProvider Create(string root)
        {
            return Create(root, ExclusionFilters.None);
        }

        public static PhysicalFileProvider Create(string root, ExclusionFilters filters)
        {
            if (!Directory.Exists(root))
            {
                _ = Directory.CreateDirectory(root);
            }
            return new PhysicalFileProvider(root, filters);
        }
    }
}
