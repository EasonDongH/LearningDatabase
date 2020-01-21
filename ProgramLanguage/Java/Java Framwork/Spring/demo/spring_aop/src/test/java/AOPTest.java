import com.easondongh.service.AccountService;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;

public class AOPTest {

    public static void main(String[] args) {
        ApplicationContext ac = new ClassPathXmlApplicationContext("bean.xml");
        AccountService accountService = (AccountService)ac.getBean("accountService");
        accountService.save();
//        accountService.transfer("aaa", "bbb",100.0 );
    }
}
