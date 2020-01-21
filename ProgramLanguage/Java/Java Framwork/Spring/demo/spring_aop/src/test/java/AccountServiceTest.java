import com.easondongh.factory.BeanFactory;
import org.junit.Test;
import com.easondongh.service.AccountService;

public class AccountServiceTest {

    @Test
    public void testTransfer(){
        BeanFactory factory = new BeanFactory();
        AccountService accountService = factory.getAccountService();
        accountService.transfer("小王", "小李", 100);
    }
}
