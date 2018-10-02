using System;
using System.Collections.Generic;
using System.Text;

namespace Infuse.Test.TestData
{
    public class Logger
    {
        private string Name;

        public Logger()
        {

        }
        public void Set(string str)
        {
            Name = str;
        }

        public string Get()
        {
            return Name;
        }

    }

    public class TestLoggerController
    {
        TestLoggerRepository _repo;
        Logger _logger;
        public TestLoggerController(TestLoggerRepository repo, Logger logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public void Update(string str)
        {
            _logger.Set(str);
        }

        public string Fetch()
        {
            return _repo.Retrieve();
        }

    }

    public class TestLoggerRepository
    {
        Logger _logger;
        public TestLoggerRepository(Logger logger)
        {
            _logger = logger;
        }

        public string Retrieve()
        {
            return _logger.Get();
        }
    }
}
