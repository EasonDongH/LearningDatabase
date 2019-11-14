package proxy;

public class Lenovo implements SaleComputer {
    @Override
    public String sale(double money) {

        System.out.println("Lenovo……" + money);
        return "联想电脑";
    }
}
