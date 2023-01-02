using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace Sandbox
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Benchmark]
        public void UserGenerator_GenerateUsers()
        {
            UserGenerator.GenerateUsers(); 
        }
        [Benchmark]
        public void UserGenerator_GenerateDynamicUsers()
        {
            UserGenerator.GenerateDynamicUsers();
        }
        [Benchmark]
        public void UserProcessor_GetUserNameWithRole()
        {
            UserProcessor.GetUserNameWithRole(UserGenerator.GenerateUsers());
        }
        [Benchmark]
        public void UserProcessor_GetUserNameWithRoleStringArithmetic()
        {
            UserProcessor.GetUserNameWithRoleStringArithmetic(UserGenerator.GenerateUsers());
        }
        [Benchmark]
        public void ObjectBoxer_BoxObject()
        {
            UserGenerator.GenerateUsers().ForEach(user => ObjectBoxer.boxObject(user));
        }
        [Benchmark]
        public void ObjectBoxer_NoBoxObject()
        {
            UserGenerator.GenerateUsers().ForEach(user => ObjectBoxer.noBoxObject(user));
        }
    }
}
