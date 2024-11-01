import express from 'express';
import { createClient } from 'redis';
import { createRequire } from 'module';
import { title } from 'process';

// 서버 열고, redis 연결 한 다음에 지금 열려있는 포트로 유니티 우리가 만들었던 게임 연동해서 통신하기
// 유니티에서도 코루틴 설명했엇고, 동기비동기 쪽이야
// 추후 require가 필요한 경우 사용
const require = createRequire(import.meta.url);

// Express 애플리케이션 생성
const app = express();
const port = 3000;
app.use(express.json());
app.use(express.urlencoded({ extended: true }));
// 기본 라우트 설정
app.get('/', async (req, res) => {
  await client.set('testkey', 'value');
  const value = await client.get('testkey');
  console.log(value);


  res.send(`결과 : ${value}`);
});

app.get('/userinfo', async (req, res) => {
  const userInfo = {
    userid: 'testid',
    level: 1,
    nickname: '사대천왕',
    email: 'sjceglobal@gmail.com',
    phone: '01055671285'
  }
  await client.set('testid', JSON.stringify(userInfo));
  const value = await client.get('testid');
  console.log(value);


  res.send(`결과 : ${value}`);
});

app.get('/login', async (req, res) => {
  const userInfo = {
    userid: 'testid',
    level: 1,
    nickname: '사대천왕',
    email: 'sjceglobal@gmail.com',
    phone: '01055671285'
  }
  await client.set('testid', JSON.stringify(userInfo));
  const value = await client.get('testid');
  console.log(value);


  res.send(`결과 : ${value}`);
});

app.post('/board', async (req, res) => { // restful api
  const board = {
    boardid: req.body.boardid,
    title: req.body.title, 
    content: req.body.content
  }

  console.log(typeof(req.body.boardid));
  await client.set(toString(req.body.boardid), JSON.stringify(board));
  res.send(`게시글이 등록되었습니다.`);

})

app.delete('/dltboard', async (req, res) => {
  await client.del(req.body.boardid);
  res.send(`게시글이 삭제되었습니다.`);
})

app.put('/updateboard', async (req, res) => {
  const boardInfo = {
    boardid: req.body.boardid,
    title: req.body.title,
    content: req.body.content,
  };
  client.set(toString(req.body.boardid), JSON.stringify(boardInfo));
  res.send(`게시글이 수정되었습니다.`);
})



// 서버 시작
app.listen(port, () => {
  console.log(`서버가 http://localhost:${port}에서 실행 중입니다.`);
});


// await -> 기다려라 -> 동기
const client = await createClient()
  .on('error', err => console.log('Redis Client Error', err))
  .connect();

// 서버 종료 시 Redis 연결 종료
process.on('SIGINT', async () => {
  await client.quit();
  console.log('Redis 연결 종료.');
  process.exit(0);
});


function delay(ms) {
  return new Promise((resolve) => {
    setTimeout(resolve, ms);
  });
}