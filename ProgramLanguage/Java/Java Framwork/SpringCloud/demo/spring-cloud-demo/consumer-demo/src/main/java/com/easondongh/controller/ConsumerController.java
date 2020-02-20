package com.easondongh.controller;

import com.easondongh.domain.User;
import com.easondongh.myinterface.UserService;
import com.netflix.hystrix.contrib.javanica.annotation.DefaultProperties;
import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
import com.netflix.hystrix.contrib.javanica.annotation.HystrixProperty;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cloud.client.ServiceInstance;
import org.springframework.cloud.client.discovery.DiscoveryClient;
import org.springframework.cloud.netflix.ribbon.RibbonClient;
import org.springframework.cloud.netflix.ribbon.RibbonLoadBalancerClient;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import javax.annotation.Resource;
import java.util.List;

/**
 * @author EasonDongH
 * @date 2020/2/19 11:26
 */
@RestController
@RequestMapping("consumer")
@DefaultProperties(defaultFallback = "defaultFallBack")
public class ConsumerController {

    @Autowired
    private RestTemplate restTemplate;

    @Resource
    private UserService userService;

//    @Autowired
//    private DiscoveryClient discoveryClient;
//
//    @RequestMapping("{id}")
//    public User query(@PathVariable("id") Long id){
//        List<ServiceInstance> instances = discoveryClient.getInstances("USER-SERVICE");
//        // 这里应该由负载均衡算法来选择实例
//        ServiceInstance instance = instances.get(0);
//        String url = "http://"+ instance.getHost() + ":" + instance.getPort() +"/user/" + id;
//        System.out.println("url="+url);
//        User user = this.restTemplate.getForObject(url, User.class);
//        return user;
//    }


//    /**
//     * 加上负载均衡策略
//     * @param id
//     * @return
//     */
//    @RequestMapping("{id}")
//    public User query(@PathVariable("id") Long id){
//        String url = "http://USER-SERVICE/user/" + id;
//        User user = this.restTemplate.getForObject(url, User.class);
//        return user;
//    }

    @RequestMapping("{id}")
//    @HystrixCommand(fallbackMethod = "queryFallBack")
//    @HystrixCommand(commandProperties = {
//            @HystrixProperty(name = "execution.isolation.thread.timeoutInMilliseconds",value = "3000")
//    })
    @HystrixCommand(commandProperties = {
            @HystrixProperty(name = "circuitBreaker.requestVolumeThreshold",value = "10"),
            @HystrixProperty(name = "circuitBreaker.sleepWindowInMilliseconds",value = "10000")
    })
    public String query(@PathVariable("id") Long id){
        // 手动控制熔断
        if((id % 2) == 0) {
            System.out.println("12111");
            throw new RuntimeException("");
        }
//        String url = "http://USER-SERVICE/user/" + id;
//        String user = this.restTemplate.getForObject(url, String.class);

        User user = this.userService.query(id);
        return user.toString();
    }

    /**
     * 特定方法的降级处理，必须保证方法列表、返回值一致
     * @param id
     * @return
     */
    public String queryFallBack(Long id){
        return "queryFallBack：服务器正忙！";
    }

    /**
     * 默认降级处理，方法列表必须为空，返回值一般为String
     * @return
     */
    public String defaultFallBack(){
        return "defaultFallBack：服务器正忙！";
    }
}
