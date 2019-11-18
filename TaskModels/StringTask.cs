using System;
using System.Threading.Tasks;

namespace TaskModels
{
    public static class StringTask
    {
        public static async Task<string> GetStringSync(string input)
        {
            return await Task.FromResult($"{input} will out output!");
        }

        public static async Task<DtoModel> GetDtoTaskAsync()
        {
            DtoModel model = new DtoModel() { Id = 12334, Name = "Yutong" };
            return await Task.FromResult(model);
        }
    }
}
