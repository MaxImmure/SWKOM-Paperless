using PaperlessRestService.BusinessLogic.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Tests
{
    public class ExceptionWrapperTests
    {
        public ExceptionWrapperTests()
        {
            dalExecuter = new DALActionExecuterMiddleware();
            blExecuter = new BLActionExecuterMiddleware();
        }

        [Fact]
        public void DAL_ExecuteAction_WithNullAction()
        {
            Action action = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                dalExecuter.Execute(action);
            });
        }

        [Fact]
        public void BL_ExecuteAction_WithNullAction()
        {
            Action action = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                blExecuter.Execute(action);
            });
        }

        [Fact]
        public void DAL_ExecuteAction_WithValidAction()
        {
            Action action = () => { };

            var exception = Record.Exception(() => dalExecuter.Execute(action));
        
            Assert.Null(exception);
        }

        [Fact]
        public void BL_ExecuteAction_WithValidAction()
        {
            Action action = () => { };

            var exception = Record.Exception(() => blExecuter.Execute(action));

            Assert.Null(exception);
        }

        [Fact]
        public void DAL_ExecuteAction_WithNullFunction()
        {
            Func<bool> action = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                dalExecuter.Execute<bool>(action);
            });
        }

        [Fact]
        public void BL_ExecuteAction_WithNullFunction()
        {
            Func<bool> action = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                blExecuter.Execute<bool>(action);
            });
        }

        [Fact]
        public void DAL_ExecuteAction_WithValidFunction()
        {
            Func<bool> action = () => { return true; };

            var exception = Record.Exception(() => dalExecuter.Execute<bool>(action));

            Assert.Null(exception);
        }

        [Fact]
        public void BL_ExecuteAction_WithValidFunction()
        {
            Func<bool> action = () => { return true; };

            var exception = Record.Exception(() => blExecuter.Execute<bool>(action));

            Assert.Null(exception);
        }

        [Fact]
        public void DAL_WrappingException()
        {
            Exception exception = new Exception("Test");

            Assert.Throws<DALException>(() =>
            {
                dalExecuter.Execute(() =>
                {
                    throw exception;
                });
            });
        }

        [Fact]
        public void BL_WrappingException()
        {
            Exception exception = new Exception("Test");

            Assert.Throws<BLException>(() =>
            {
                blExecuter.Execute(() =>
                {
                    throw exception;
                });
            });
        }


        private DALActionExecuterMiddleware dalExecuter;
        private BLActionExecuterMiddleware blExecuter;
    }
}
