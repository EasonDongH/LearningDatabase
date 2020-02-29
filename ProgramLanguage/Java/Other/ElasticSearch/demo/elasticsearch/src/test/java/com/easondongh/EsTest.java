package com.easondongh;

import com.easondongh.pojo.Item;
import com.easondongh.repository.ItemRepository;
import org.elasticsearch.index.query.MatchQueryBuilder;
import org.elasticsearch.index.query.QueryBuilders;
import org.elasticsearch.search.aggregations.Aggregation;
import org.elasticsearch.search.aggregations.AggregationBuilders;
import org.elasticsearch.search.aggregations.Aggregations;
import org.elasticsearch.search.aggregations.bucket.terms.StringTerms;
import org.elasticsearch.search.sort.SortBuilders;
import org.elasticsearch.search.sort.SortOrder;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.elasticsearch.core.ElasticsearchTemplate;
import org.springframework.data.elasticsearch.core.aggregation.AggregatedPage;
import org.springframework.data.elasticsearch.core.query.FetchSourceFilter;
import org.springframework.data.elasticsearch.core.query.NativeSearchQueryBuilder;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.ArrayList;
import java.util.List;

/**
 * @author EasonDongH
 * @date 2020/2/28 22:42
 */
@RunWith(SpringRunner.class)
@SpringBootTest(classes = EsApplication.class)
public class EsTest {

    @Autowired
    private ElasticsearchTemplate esTemplate;
    @Autowired
    private ItemRepository itemRepository;

    @Test
    public void testCreateIndex(){
        this.esTemplate.createIndex(Item.class);
        this.esTemplate.putMapping(Item.class);
    }

    @Test
    public void testDeleteIndex() {
        esTemplate.deleteIndex("heima");
    }

    @Test
    public void testAddDoc(){
        Item item = new Item(1L, "小米手机7", " 手机",
                "小米", 3499.00, "http://image.leyou.com/13123.jpg");
        itemRepository.save(item);
    }

    /**
     * 批量新增
     */
    @Test
    public void testAddDocList() {
        List<Item> list = new ArrayList<>();
        list.add(new Item(1L, "小米手机7", "手机", "小米", 3299.00, "http://image.leyou.com/13123.jpg"));
        list.add(new Item(2L, "坚果手机R1", "手机", "锤子", 3699.00, "http://image.leyou.com/13123.jpg"));
        list.add(new Item(3L, "华为META10", "手机", "华为", 4499.00, "http://image.leyou.com/13123.jpg"));
        list.add(new Item(4L, "小米Mix2S", "手机", "小米", 4299.00, "http://image.leyou.com/13123.jpg"));
        list.add(new Item(5L, "荣耀V10", "手机", "华为", 2799.00, "http://image.leyou.com/13123.jpg"));
        // 接收对象集合，实现批量新增
        itemRepository.saveAll(list);
    }

    @Test
    public void testDelete(){
        itemRepository.deleteAll();
    }

    @Test
    public void queryByPriceBetween(){
        List<Item> list = this.itemRepository.findByPriceBetween(2000.00, 3500.00);
        for (Item item : list) {
            System.out.println("item = " + item);
        }
    }

    @Test
    public void testQuery(){
        // 词条查询
        MatchQueryBuilder queryBuilder = QueryBuilders.matchQuery("title", "小米");
        // 执行查询
        Iterable<Item> items = this.itemRepository.search(queryBuilder);
        items.forEach(System.out::println);
    }

    /**
     * 过滤
     */
    @Test
    public void testNativeQuery(){
        // 构建查询条件
        NativeSearchQueryBuilder queryBuilder = new NativeSearchQueryBuilder();
        // 结果过滤
        queryBuilder.withSourceFilter(new FetchSourceFilter(new String[]{"id","title","price"}, null));
        // 添加基本的分词查询
        queryBuilder.withQuery(QueryBuilders.matchQuery("title", "小米"));
        // 执行搜索，获取结果
        Page<Item> items = this.itemRepository.search(queryBuilder.build());
        // 打印总条数
        System.out.println(items.getTotalElements());
        // 打印总页数
        System.out.println(items.getTotalPages());
        items.forEach(System.out::println);
    }

    @Test
    public void testSort(){
        // 构建查询条件
        NativeSearchQueryBuilder queryBuilder = new NativeSearchQueryBuilder();
        // 添加基本的分词查询
        queryBuilder.withQuery(QueryBuilders.termQuery("category", "手机"));

        // 排序
        queryBuilder.withSort(SortBuilders.fieldSort("price").order(SortOrder.DESC));

        // 执行搜索，获取结果
        Page<Item> items = this.itemRepository.search(queryBuilder.build());
        // 打印总条数
        System.out.println(items.getTotalElements());
        items.forEach(System.out::println);
    }

    /**
     * 分页，页码从0开始
     */
    @Test
    public void testNativeQuery1(){
        // 构建查询条件
        NativeSearchQueryBuilder queryBuilder = new NativeSearchQueryBuilder();
        // 添加基本的分词查询
        queryBuilder.withQuery(QueryBuilders.termQuery("category", "手机"));

        // 初始化分页参数
        int page = 0;
        int size = 3;
        // 设置分页参数
        queryBuilder.withPageable(PageRequest.of(page, size));

        // 执行搜索，获取结果
        Page<Item> items = this.itemRepository.search(queryBuilder.build());
        // 打印总条数
        System.out.println(items.getTotalElements());
        // 打印总页数
        System.out.println(items.getTotalPages());
        // 每页大小
        System.out.println(items.getSize());
        // 当前页
        System.out.println(items.getNumber());
        // 当前内容
        List<Item> content = items.getContent();

        items.forEach(System.out::println);
    }

    /**
     * 聚合
     */
    @Test
    public void testAgg(){
        NativeSearchQueryBuilder queryBuilder = new NativeSearchQueryBuilder();
        // 不查询任何结果
        queryBuilder.withSourceFilter(new FetchSourceFilter(new String[]{""}, null));
        // 1、添加一个新的聚合，聚合类型为terms，聚合名称为brands，聚合字段为brand
        queryBuilder.addAggregation(
                AggregationBuilders.terms("brands").field("brand"));
        // 2、查询,需要把结果强转为AggregatedPage类型
        AggregatedPage<Item> aggPage = (AggregatedPage<Item>) this.itemRepository.search(queryBuilder.build());
        // 3、解析
        // 3.1、从结果中取出名为brands的那个聚合，
        // 因为是利用String类型字段来进行的term聚合，所以结果要强转为StringTerm类型
        StringTerms agg = (StringTerms) aggPage.getAggregation("brands");
        // 3.2、获取桶
        List<StringTerms.Bucket> buckets = agg.getBuckets();
        // 3.3、遍历
        for (StringTerms.Bucket bucket : buckets) {
            // 3.4、获取桶中的key，即品牌名称
            System.out.println(bucket.getKeyAsString());
            // 3.5、获取桶中的文档数量
            System.out.println(bucket.getDocCount());
        }

    }

    /**
     * 聚合：使用ElasticsearchTemplate
     */
    @Test
    public void testAgg1() {
        NativeSearchQueryBuilder queryBuilder = new NativeSearchQueryBuilder();
        String aggName = "brands";
        // 聚合
        queryBuilder.addAggregation(
                AggregationBuilders.terms(aggName).field("brand"));
        AggregatedPage<Item> result = this.esTemplate.queryForPage(queryBuilder.build(), Item.class);
        // 解析聚合
        Aggregations aggs = result.getAggregations();
        // 获取聚合结果词条
        StringTerms terms = aggs.get(aggName);
        // 获取桶
        List<StringTerms.Bucket> buckets = terms.getBuckets();
        for (StringTerms.Bucket bucket : buckets) {
            System.out.println("bucket.getKeyAsString() = " + bucket.getKeyAsString());
            System.out.println("bucket.getDocCount() = " + bucket.getDocCount());
        }
    }
}
