using System;
using System.Collections.Generic;
using System.Text;

namespace Infuse.Test.TestData
{
    public class DeepController
    {
        DeepBusiness _helper;
        public DeepController(DeepBusiness helper)
        {
            _helper = helper;
        }

        public string Fetch()
        {
            return _helper.Retrieve();
        }

    }

    public class DeepBusiness
    {
        private IDeepRepository _repo;

        public DeepBusiness(IDeepRepository repo)
        {
            _repo = repo;
        }

        public string Retrieve()
        {
            return _repo.Get();
        }
    }

    public interface IDeepRepository
    {
        void Update(string msg);
        string Get();
    }

    public class DeepRepository : IDeepRepository
    {
        Logger _logger;
        public DeepRepository(Logger logger)
        {
            _logger = logger;
        }

        public void Update(string msg)
        {
            _logger.Set(msg);
        }

        public string Get()
        {
            return _logger.Get();
        }
    }
}
