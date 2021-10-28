using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /**
             * 1. Ví dụ về thread: Khi run nó sẽ chạy xong có thể chạy 111 trước sau đó 0 và ngược lại, có thể chạy xen kẻ 
             */
            //Thread thread = new Thread(MethodA);
            //thread.Start();
            //MethodB();

            /**
             * 2. Truyền tham số cho thread    
             * => Ta sẽ tạo một thread với function callback có params là object
             * => Sau đó khi gọi start thread đó ta cũng sẽ cho dữ liệu là object vào param của hàm Start            
             */

            /*Thread t2 = new Thread((obj) =>
            {
                Student st = (Student)obj;
                Console.Write(st.Name + "\t" + st.Birthday.ToShortDateString());
            });

            t2.Start(new Student()
            {
                Name = "Yin",
                Birthday = new DateTime(1999, 10, 10),
            });
            Console.Read();*/


            /**
             * 3. Các thuộc tính của Thread
             *  + ThreadState: Kiểm tra trạng thái hiện tại của thread
             *  + ThreadPriority: Check độ ưu tiên của thread được thực thi so với các thread khác theo thứ tự: Lowest, BelowNormal, Normal,AboveNormal và Highest 
             * 
             */

            /*Thread threadState = new Thread(MethodA);
            threadState.Start();
            var currentState = threadState.ThreadState;

            Console.WriteLine("Current1: " + currentState);
            MethodB();
            Console.WriteLine("Current2: " + currentState);
            */

            /**
             * 4. Các phương thức thông dụng: 
             *  + Abort: Stopped thread
             *  + Suspend: Tạm dùng thực thi thread cho đến khi có phương thức resume
             *  + Sleep: Dùng trong khoảng thời gian nhất định tính bằng miliseconds
             *  + Join: Dùng để handle việc nếu thread đó kết thúc sẽ đến thread nào chạy giống async await              
             */

            Thread threadState = new Thread(MethodA);
            Thread thread2 = new Thread(MethodB);
            Thread thread3 = new Thread(MethodC);

            threadState.Start();
            thread2.Start();

            // Join
            threadState.Join();
            thread3.Start();

            // Abort
            //threadState.Abort();
            //MethodB();


        }

        static void MethodA()
        {
            // 4. Sleep
            //Thread.Sleep(1000); // Delay 1000 milisecond
             
            for (int i = 0; i < 100; i++)
            {
                Console.Write("0");
            }
            Console.WriteLine("");

        }

        static void MethodB()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("1");
            }
            Console.WriteLine("");

        }

        static void MethodC()
        {
            // 4. Sleep
            //Thread.Sleep(1000); // Delay 1000 milisecond

            for (int i = 0; i < 100; i++)
            {
                Console.Write("2");
            }
            Console.WriteLine("");

        }
    }
}
