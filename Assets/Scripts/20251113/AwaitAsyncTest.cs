using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

/*
 ✨ async와 await 설명
async와 await는 C#에서 **비동기 프로그래밍(Asynchronous Programming)**을 
간결하고 효율적으로 처리하기 위해 도입된 키워드입니다. 

이 키워드들을 사용하면 I/O 작업(네트워크, 파일 처리)처럼 
시간이 오래 걸리는 작업을 메인 스레드를 블록하지 않고 실행할 수 있어 
애플리케이션의 응답성과 성능을 크게 향상시킵니다.


1. async (비동기 메서드 선언)
async 키워드는 메서드가 비동기적으로 실행될 수 있음을 선언합니다.

역할: 컴파일러에게 이 메서드 내에 하나 이상의 await 호출이 포함될 것이며, 
메서드의 실행 흐름을 일시 중단할 수 있음을 알려줍니다.


반환 타입: async 메서드는 일반적으로 다음 세 가지 타입 중 하나를 반환해야 합니다.

Task<T>: 비동기 작업이 완료된 후 T 타입의 결과를 반환하는 경우.

Task: 비동기 작업이 완료된 후 결과 없이 반환하는 경우.

void: 이벤트 핸들러 등 특별한 경우에만 사용되며, 
비동기 작업의 예외 처리가 어려워 일반적으로는 권장되지 않습니다. 
(Unity의 async void는 MonoBehaviour의 시작 지점에서 자주 사용됩니다.)


2. await (작업 대기 및 실행 일시 중지)
await 키워드는 async 메서드 내에서만 사용할 수 있으며, 
비동기 작업이 완료되기를 기다리는 시점을 나타냅니다.

역할: await가 호출되면, await 대상(Task)의 작업이 완료될 때까지 메서드의 나머지 실행을 일시 중단합니다.

핵심 작동: 메서드가 일시 중단되는 동안, 제어권은 호출자에게 즉시 반환됩니다. 
덕분에 애플리케이션의 메인 스레드는 블록되지 않고 
다른 유용한 작업(예: Unity의 프레임 업데이트, UI 갱신)을 계속 수행할 수 있습니다.

재개: await 대상 작업이 완료되면, 메서드는 중단되었던 지점부터 실행을 재개합니다.
 */

public class AwaitAsyncTest : MonoBehaviour
{
    /*
     Unity의 async/await 작업에서는 CancellationToken을 사용하여 오브젝트가 파괴되거나 씬이 전환될 때 
    실행 중인 작업을 안전하게 취소하는 것이 중요합니다 
    (위 예시의 cts.Token 사용). 
    이는 코루틴의 StopCoroutine과 유사한 역할을 합니다.

    CancellationTokenSource는 C#에서 비동기 작업(Asynchronous Operations)을 
    취소하기 위한 메커니즘을 제공하는 클래스입니다. 
    이는 async/await 패턴이나 Task 기반의 비동기 작업에서 
    안전하게 외부에서 작업을 중단시키는 데 필수적입니다.
     */

    private CancellationTokenSource cts = new CancellationTokenSource();

    private float _laptime = 0.5f;
    private float _spendTime = 0.0f;
    private int _count = 0;
    private bool _isStop = false;

    void Start()
    {
        StartTimerAsync();
    }

    private async void StartTimerAsync()
    {
        int i = 0;
        try
        {
            while (!_isStop)
            {
                Debug.Log($"남은 시간: {i++}초");

                // 1초 동안 비동기적으로 대기합니다. (메인 스레드 블록하지 않음)
                await Task.Delay(1000, cts.Token);
            }

            Debug.Log("카운트다운 완료!");
            _isStop = true;
        }
        catch (TaskCanceledException)
        {
            Debug.Log("타이머 취소됨");
        }

    }

    private void OnDestroy()
    {
        // 오브젝트가 파괴될 때 비동기 작업을 취소하여 에러를 방지합니다.
        cts.Cancel();  // 연결된 모든 Task에 취소 신호를 보냄
        cts.Dispose(); // 리소스 해제
    }

    void Update()
    {
        if (!_isStop)
        {
            _spendTime += Time.deltaTime;
            if (_spendTime >= _laptime)
            {
                Debug.Log($"Update count = {_count++}");
                _spendTime = 0.0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isStop = true;
        }
    }
}
