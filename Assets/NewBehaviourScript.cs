using Rougamo;
using Rougamo.Context;
using UnityEngine;


public class LoggingAttribute : MoAttribute
{
    public override void OnEntry(MethodContext context)
    {
        // 从context对象中能取到包括入参、类实例、方法描述等信息
        Debug.Log("方法执行前");
    }

    public override void OnException(MethodContext context)
    {
        Debug.LogError("方法执行异常" + context.Exception);
    }

    public override void OnSuccess(MethodContext context)
    {
        Debug.Log("方法执行成功后");
    }

    public override void OnExit(MethodContext context)
    {
        Debug.Log("方法退出时，不论方法执行成功还是异常，都会执行");
    }
}

public static class Test
{
    [Logging]
    public static void TestA()
    {
        Debug.Log("TestA");
    }
}


public class NewBehaviourScript : MonoBehaviour
{
    [Logging]
    private void Awake()
    {
        Debug.Log("Update");
        
        Test.TestA();
    }
}
