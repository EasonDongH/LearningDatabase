package com.easondongh.lucene;

import org.apache.commons.io.FileUtils;
import org.apache.lucene.analysis.Analyzer;
import org.apache.lucene.analysis.TokenStream;
import org.apache.lucene.analysis.standard.StandardAnalyzer;
import org.apache.lucene.analysis.tokenattributes.CharTermAttribute;
import org.apache.lucene.document.Document;
import org.apache.lucene.document.Field;
import org.apache.lucene.document.TextField;
import org.apache.lucene.index.*;
import org.apache.lucene.search.*;
import org.apache.lucene.store.Directory;
import org.apache.lucene.store.FSDirectory;
import org.junit.Test;
import org.wltea.analyzer.lucene.IKAnalyzer;

import java.io.File;

public class LuceneFirst {

    /**
     * 创建索引库
     * @throws Exception
     */
    @Test
    public void createIndex() throws Exception{
        //1、创建一个Director对象，指定索引库保存的位置。
        //把索引库保存在内存中
        //Directory directory = new RAMDirectory();
        //把索引库保存在磁盘
        Directory directory = FSDirectory.open(new File("C:\\temp\\index").toPath());
        //2、基于Directory对象创建一个IndexWriter对象
//        IndexWriter indexWriter = new IndexWriter(directory,new IndexWriterConfig());
        IndexWriterConfig indexWriterConfig = new IndexWriterConfig(new IKAnalyzer());
        IndexWriter indexWriter = new IndexWriter(directory,indexWriterConfig);
        //3、读取磁盘上的文件，对应每个文件创建一个文档对象
        File dir = new File("D:\\学习资料\\编程语言\\Java\\黑马\\00.讲义+笔记+资料\\流行框架\\61.会员版(2.0)-就业课(2.0)-Lucene\\87.lucene\\lucene\\02.参考资料\\searchsource");
        File[] files = dir.listFiles();
        for (File file : files) {
            //文件名
            String fileName = file.getName();
            //文件的路径
            String filePath = file.getPath();
            //文件的内容
            String fileContent = FileUtils.readFileToString(file, "utf-8");
            //文件的大小
            long fileSize = FileUtils.sizeOf(file);
            //创建Field
            //参数1：域的名称，参数2：域的内容，参数3：是否存储
            Field fieldName = new TextField("name", fileName, Field.Store.YES);
            Field fieldPath = new TextField("path", filePath, Field.Store.YES);
            Field fieldContent = new TextField("content", fileContent, Field.Store.YES);
            Field fieldSize = new TextField("size", fileSize + "", Field.Store.YES);
            //创建文档对象
            Document document = new Document();
            //向文档对象中添加域
            document.add(fieldName);
            document.add(fieldPath);
            document.add(fieldContent);
            document.add(fieldSize);
            //5、把文档对象写入索引库
            indexWriter.addDocument(document);
        }
        indexWriter.close();
    }

    @Test
    public void searchIndex() throws Exception{
        //1、创建一个Director对象，指定索引库的位置
        Directory directory = FSDirectory.open(new File("C:\\temp\\index").toPath());
        //2、创建一个IndexReader对象
        IndexReader indexReader = DirectoryReader.open(directory);
        //3、创建一个IndexSearcher对象，构造方法中的参数indexReader对象
        IndexSearcher indexSearcher = new IndexSearcher(indexReader);
        //4、创建一个Query对象，TermQuery
        Query query = new TermQuery(new Term("content", "全文"));
        //5、执行查询，得到一个TopDocs对象
        //参数1：查询对象 参数2：查询结果返回的最大记录数
        TopDocs topDocs = indexSearcher.search(query, 10);
        //6、取查询结果的总记录数
        System.out.println("查询记录总数：" + topDocs.totalHits);
        //7、取文档列表
        ScoreDoc[] scoreDocs = topDocs.scoreDocs;
        for (ScoreDoc scoreDoc : scoreDocs) {
            //取文档id
            int docId = scoreDoc.doc;
            //根据id取文档对象
            Document document = indexSearcher.doc(docId);
            System.out.println(document.get("name"));
            System.out.println(document.get("path"));
            //System.out.println(document.get("content"));
            System.out.println(document.get("size"));
            System.out.println("--------------------------------");
        }
        indexReader.close();
    }

    /**
     * 测试分析器效果
     * @throws Exception
     */
    @Test
    public void testToKenStream() throws Exception{
        //1）创建一个Analyzer对象，StandardAnalyzer对象
        Analyzer analyzer = new StandardAnalyzer();
        //2）使用分析器对象的tokenStream方法获得一个TokenStream对象
        String text1 = "Lucene Core, our flagship sub-project, provides Java-based indexing and search technology, as well as spellchecking, hit highlighting and advanced analysis/tokenization capabilities.";
        TokenStream tokenStream = analyzer.tokenStream("", text1);
        //3）向TokenStream对象中设置一个引用，相当于数一个指针
        CharTermAttribute charTermAttribute = tokenStream.addAttribute(CharTermAttribute.class);
        //4）调用TokenStream对象的rest方法。如果不调用抛异常
        tokenStream.reset();
        //5）使用while循环遍历TokenStream对象
        while(tokenStream.incrementToken()){
            System.out.println(charTermAttribute.toString());
        }
        tokenStream.close();
    }
}
