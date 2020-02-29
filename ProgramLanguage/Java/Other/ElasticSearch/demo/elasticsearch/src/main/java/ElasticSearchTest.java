//import org.apache.http.HttpHost;
//import org.elasticsearch.action.admin.indices.delete.DeleteIndexRequest;
//import org.elasticsearch.action.delete.DeleteRequest;
//import org.elasticsearch.action.index.IndexRequest;
//import org.elasticsearch.action.search.SearchRequest;
//import org.elasticsearch.action.search.SearchResponse;
//import org.elasticsearch.client.RequestOptions;
//import org.elasticsearch.client.RestClient;
//import org.elasticsearch.client.RestHighLevelClient;
//import org.elasticsearch.client.indices.CreateIndexRequest;
//import org.elasticsearch.common.settings.Settings;
//import org.elasticsearch.common.text.Text;
//import org.elasticsearch.common.unit.TimeValue;
//import org.elasticsearch.common.xcontent.XContentType;
//import org.elasticsearch.index.query.QueryBuilder;
//import org.elasticsearch.index.query.QueryBuilders;
//import org.elasticsearch.search.SearchHit;
//import org.elasticsearch.search.SearchHits;
//import org.elasticsearch.search.builder.SearchSourceBuilder;
//import org.elasticsearch.search.fetch.subphase.highlight.HighlightBuilder;
//import org.elasticsearch.search.fetch.subphase.highlight.HighlightField;
//import org.junit.After;
//import org.junit.Before;
//import org.junit.Test;
//
//import java.io.IOException;
//import java.util.Map;
//import java.util.concurrent.TimeUnit;

/**
 * @author EasonDongH
 * @date 2020/1/15 16:37
 */
public class ElasticSearchTest {

//    private static final String Index_Name = "index_hello";
//
//    private  RestHighLevelClient client = null;
//
//    @Before
//    public void buildClient(){
//        if(client == null) {
//            // 添加节点
//             client = new RestHighLevelClient(RestClient.builder(
//                    new HttpHost("127.0.0.1", 9201, "http"),
//                    new HttpHost("127.0.0.1", 9202, "http"),
//                    new HttpHost("127.0.0.1", 9203, "http")
//            ));
//        }
//    }
//
//    @After
//    public void disposeClient() throws IOException {
//        if(client != null) {
//            client.close();
//            client = null;
//        }
//    }
//
//    /**
//     * 创建索引
//     * @throws Exception
//     */
//    @Test
//    public void createIndex() throws Exception {
//        CreateIndexRequest request = new CreateIndexRequest(Index_Name);
//        request.source("{\n" +
//                "    \"settings\" : {\n" +
//                "        \"number_of_shards\" : 5,\n" +
//                "        \"number_of_replicas\" : 1\n" +
//                "    },\n" +
//                "   \"mappings\":{\n" +
//                "        \"properties\":{\n" +
//                "            \"id\":{\"type\":\"long\", \"store\":true},\n" +
//                "            \"title\":{\"type\":\"text\", \"analyzer\":\"ik_smart\"},\n" +
//                "            \"content\":{\"type\":\"text\", \"analyzer\":\"ik_smart\"}\n" +
//                "        }\n" +
//                "    },\n" +
//                "    \"aliases\" : {\n" +
//                "        \"twitter_alias\" : {}\n" +
//                "    }\n" +
//                "}", XContentType.JSON);
//
//        client.indices().create(request, RequestOptions.DEFAULT);
//    }
//
//    /**
//     * 删除索引
//     */
//    @Test
//    public void deleteIndex() throws Exception {
//        DeleteIndexRequest index = new DeleteIndexRequest(Index_Name);
//        client.indices().delete(index,RequestOptions.DEFAULT );
//    }
//
//    /**
//     * 创建文档
//     * @param id 索引id
//     * @param cid 内容id
//     * @param title
//     * @param content
//     */
//    private void createDocument(String id, String cid, String title, String content) throws IOException {
//        IndexRequest request = new IndexRequest(Index_Name);
//        request.id(id);
//        String jsonString = String.format( "{" +
//                "\"id\":\"%s\"," +
//                "\"title\":\"%s\"," +
//                "\"content\":\"%s\"" +
//                "}", cid, title, content);
//        request.source(jsonString, XContentType.JSON);
//
//        this.client.index(request, RequestOptions.DEFAULT);
//    }
//
//    @Test
//    public void createDocument() throws IOException {
//        testAddDoucment(100);
//    }
//
//    public void testAddDoucment(int cnt) throws IOException {
//        for(int i=1; i<=cnt; i++) {
//            createDocument(i + "",i+"",
//                    "全球首个活体机器人诞生 靠自己活动、可编程、会自愈",
//                    "世界首个用细胞制作的活体机器人,已经诞生。不用金属、塑料打造,而是采用细胞重组,科幻电影《终结者2》中的T-1000反派角色似乎是迎面扑来。" );
//        }
//    }
//
//    @Test
//    public void deleteDocument() throws IOException {
//        DeleteRequest request = new DeleteRequest(Index_Name, "1");
//        this.client.delete(request,RequestOptions.DEFAULT );
//    }
//
//    /**
//     * 关键词查询
//     */
//    @Test
//    public void search() throws IOException {
//        SearchSourceBuilder sourceBuilder = new SearchSourceBuilder();
//        // 根据id进行查询
//        // sourceBuilder.query(QueryBuilders.idsQuery().addIds("1", "2"));
//        // 根据字段进行查询（完全匹配）
//         //sourceBuilder.query(QueryBuilders.termQuery("content", "编程"));
//        // 带解析的查询
//        sourceBuilder.query(QueryBuilders.queryStringQuery("首个"));
//
//        // 查询匹配结果高亮
//        HighlightBuilder highlightBuilder = new HighlightBuilder();
//        highlightBuilder.field("title");
//        highlightBuilder.preTags("<em>");
//        highlightBuilder.postTags("</em>");
//
//        // 分页处理
//        sourceBuilder.from(0);
//        sourceBuilder.size(10);
//        sourceBuilder.highlighter(highlightBuilder);
//        sourceBuilder.timeout(new TimeValue(60, TimeUnit.SECONDS));
//
//        SearchRequest searchRequest = new SearchRequest();
//        searchRequest.indices(Index_Name);
//        searchRequest.source(sourceBuilder);
//
//        SearchResponse searchResponse = client.search(searchRequest, RequestOptions.DEFAULT);
//        SearchHits hits = searchResponse.getHits();
//        SearchHit[] searchHits = hits.getHits();
//        for (SearchHit hit : searchHits) {
//            // do something with the SearchHit
//            String index = hit.getIndex();
//            String id = hit.getId();
//            float score = hit.getScore();
//            String sourceAsString = hit.getSourceAsString();
//            System.out.println(String.format("index=%s; id=%s; score=%s; sourceAsString=%s", index, id, score, sourceAsString));
//            System.out.println("----------document----------");
//            Map<String, Object> sourceAsMap = hit.getSourceAsMap();
//            String cid = (String) sourceAsMap.get("id");
//            String title = (String) sourceAsMap.get("title");
//            String content = (String) sourceAsMap.get("content");
//            System.out.println(String.format("id=%s; title=%s; content=%s", cid, title, content));
//            System.out.println("----------highlight----------");
//            Map<String, HighlightField> highlightFields = hit.getHighlightFields();
//            for (Map.Entry<String,HighlightField> fieldEntry : highlightFields.entrySet()) {
//                System.out.println("key=" + fieldEntry.getKey());
//                System.out.println("fragments:");
//                Text[] fragments = fieldEntry.getValue().getFragments();
//                if(fragments != null) {
//                    for (Text fragment : fragments) {
//                        System.out.println(fragment.toString());
//                    }
//                }
//            }
//            System.out.println();
//        }
//    }


}
