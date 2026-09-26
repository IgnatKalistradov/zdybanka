# Roadmap — Здибанка

# Зміст

1. [WEEK 1 — Foundation & Business Documentation](#week-1)
2. [WEEK 2 — DDD, Architecture & Backend Foundation](#week-2)
3. [WEEK 3 — API Contract & Events CRUD](#week-3)
4. [WEEK 4 — Authentication & Users](#week-4)
5. [WEEK 5 — Event Participation, Geo & Resilience](#week-5)
6. [WEEK 6 — Map, Chat & Realtime](#week-6)
7. [WEEK 7 — Testing & Quality](#week-7)
8. [WEEK 8 — Docker & CI/CD](#week-8)
9. [WEEK 9 — Observability & Kubernetes Architecture](#week-9)
10. [WEEK 10 — Kubernetes Deployment & Final Stabilization](#week-10)
11. [Загальна послідовність](#загальна-послідовність)


## WEEK 1

### Foundation & Business Documentation

* створити репозиторій та базову структуру проєкту;
* налаштувати Git workflow;
* створити `docs/`;
* завершити `docs/business_doc.md`:

  * назва та опис системи;
  * ролі;
  * основні сценарії використання;
  * функціональні вимоги;
  * нефункціональні вимоги;
  * обмеження;
* створити загальну архітектурну діаграму:

  * Client;
  * Backend;
  * Database;
  * зовнішні сервіси;
  * майбутні модулі;
* створити початковий `docs/roadmap.md`;
* визначити основні піддомени:

  * Users / Auth;
  * Events;
  * Chat;
* визначити ключові сутності та їхні зв'язки;
* почати `docs/domain/entities.md`;
* створити `docs/domain/glossary.md`;
* визначити 5–10 ключових термінів предметної області.

**DoD:**

* репозиторій має базову структуру;
* `docs/business_doc.md` готовий;
* архітектурна діаграма готова;
* визначені піддомени та ключові сутності;
* `entities.md` та `glossary.md` створені;
* roadmap знаходиться в репозиторії.

---

## WEEK 2

### DDD, Architecture & Backend Foundation

* завершити DDD-моделювання:

  * уточнити bounded contexts;
  * створити context map;
  * визначити межі модулів;
* додати `docs/domain/context_map.png`;
* створити початкові domain-моделі в коді;
* прийняти остаточне рішення щодо **модульного моноліту**;
* створити `docs/adr/0001-architecture-style.md`;
* створити `docs/adr/0002-layered-architecture.md`;
* зафіксувати:

  * структуру `api/`;
  * `service/`;
  * `domain/`;
  * напрямок залежностей;
  * заборонені залежності;
* створити ASP.NET Core backend;
* реалізувати структуру модулів;
* налаштувати PostgreSQL;
* підключити Entity Framework Core;
* спроєктувати основні таблиці та зв'язки;
* додати PostGIS;
* створити міграції;
* реалізувати `GET /health`;
* створити базовий Flutter-проєкт;
* налаштувати базовий HTTP-запит Flutter → API.

**DoD:**

* context map готовий;
* domain-моделі присутні в коді;
* є 3 ADR:

  * architecture style;
  * layered architecture;
  * початкове рішення щодо API/error model можна підготувати тут;
* ASP.NET запускається;
* PostgreSQL підключений;
* міграції застосовуються;
* `GET /health` повертає `{ "status": "ok" }`;
* Flutter може виконати HTTP-запит до API.

---

## WEEK 3

### API Contract & Events CRUD

* створити `docs/adr/0003-api-style-and-error-model.md`;
* визначити REST-стиль API;
* визначити політику HTTP status codes;
* визначити єдиний `ErrorResponse`;
* створити `docs/api/openapi.yaml`;
* описати CRUD для подій:

  * `POST /events`;
  * `GET /events`;
  * `GET /events/{id}`;
  * `PUT/PATCH /events/{id}`;
  * `DELETE /events/{id}`;
* описати DTO:

  * CreateRequest;
  * UpdateRequest;
  * Response;
  * ErrorResponse;
* перевірити OpenAPI через Swagger Editor;
* зберегти `docs/api/swagger_screenshot.png`;
* додати розділ API documentation у README;
* реалізувати CRUD подій;
* реалізувати DTO mapping:

  * DTO ↔ service;
  * service ↔ domain;
* додати валідацію;
* не допускати прямого доступу `api → database`;
* реалізувати збереження координат події;
* підключити Flutter до API подій.

**DoD:**

* `openapi.yaml` валідний у Swagger Editor;
* screenshot Swagger Editor збережений;
* OpenAPI відповідає фактичному API;
* CRUD подій працює;
* API повертає DTO;
* domain entities не використовуються безпосередньо як API contract;
* єдиний `ErrorResponse` використовується API;
* `api/` не звертається напряму до БД;
* Flutter отримує список подій.

---

## WEEK 4

### Authentication & Users

* реалізувати реєстрацію;
* реалізувати авторизацію;
* реалізувати вихід;
* додати authentication;
* додати authorization;
* реалізувати ролі:

  * `User`;
  * `Administrator`;
* реалізувати профіль користувача;
* реалізувати:

  * перегляд профілю;
  * редагування профілю;
  * зміну пароля;
* захистити endpoints;
* захистити адміністративні операції;
* додати authentication до Flutter;
* реалізувати збереження authentication state;
* додати тести service-рівня:

  * успішний сценарій;
  * помилковий сценарій.

**DoD:**

* користувач може зареєструватися;
* користувач може авторизуватися;
* protected endpoints недоступні без авторизації;
* адміністративні endpoints захищені роллю;
* Flutter працює з авторизованим користувачем;
* є щонайменше 2 service-level unit tests:

  * success;
  * error;
* тести проходять локально.

---

## WEEK 5

### Event Participation, Geo & Resilience

#### Events

* реалізувати доєднання до події;
* реалізувати вихід із події;
* реалізувати список учасників;
* додати максимальну кількість учасників;
* реалізувати перевірку доступності місць;
* реалізувати фільтрацію;
* реалізувати сортування;
* реалізувати пошук за відстанню;
* інтегрувати PostGIS;
* реалізувати перегляд деталей події;
* реалізувати відповідні сценарії на Flutter.

#### Error Handling & Resilience

* уніфікувати error handling;
* реалізувати формат:

```json
{
  "error": "...",
  "code": "...",
  "details": "...",
  "requestId": "..."
}
```

* додати `X-Request-Id` до кожної відповіді;
* дублювати `requestId` у тілі помилки;
* реалізувати `Idempotency-Key` для відповідних POST-операцій;
* забезпечити відсутність дублювання side effects;
* реалізувати `429 Too Many Requests`;
* додати `Retry-After`;
* реалізувати client-side timeout;
* реалізувати обмежені retries;
* використати exponential backoff;
* додати jitter;
* retries для 5xx та мережевих помилок;
* реалізувати degraded mode на Flutter:

  * банер/стан перевантаження;
  * тимчасове вимкнення відповідних кнопок.

**DoD:**

* користувач може повністю працювати з подіями;
* працює пошук за відстанню;
* повторний POST з тим самим `Idempotency-Key` не створює дубль;
* кожна відповідь має `X-Request-Id`;
* `429` містить `Retry-After`;
* Flutter очікує відповідно до `Retry-After`;
* retries використовують backoff + jitter;
* timeout коректно перериває запит;
* degraded mode відображається після послідовних помилок;
* `/health` повертає очікуваний статус.

---

## WEEK 6

### Map, Chat & Realtime

#### Map

* інтегрувати `flutter_osm_plugin`;
* підключити OpenStreetMap;
* відображати події на карті;
* показувати події маркерами;
* реалізувати перехід із маркера до деталей події;
* синхронізувати список та карту.

#### Chat

* автоматично створювати чат для події;
* реалізувати зв'язок `Event → Chat`;
* реалізувати історію повідомлень;
* реалізувати надсилання текстових повідомлень;
* інтегрувати SignalR;
* реалізувати отримання повідомлень у реальному часі;
* обмежити доступ до чату учасниками відповідної події;
* реалізувати перегляд чатів на Flutter;
* реалізувати перегляд повідомлень на Flutter.

#### Адміністрування

* реалізувати адміністративне видалення:

  * подій;
  * користувачів;
  * тегів;
  * чатів;
  * повідомлень;
* доступ — через API / Swagger або OpenAPI;
* окремий адміністративний frontend не створювати.

**DoD:**

* події відображаються на OpenStreetMap;
* працює навігація `карта → подія`;
* для події існує чат;
* учасники можуть обмінюватися повідомленнями через SignalR;
* історія повідомлень зберігається;
* неучасник не може отримати доступ до чату;
* адміністративні операції працюють через API.

---

## WEEK 7

### Testing & Quality

* розширити unit tests;
* додати integration/API tests;
* тестувати:

  * authentication;
  * authorization;
  * Events CRUD;
  * participation;
  * filtering;
  * geo queries;
  * chat;
  * адміністративні операції;
  * error handling;
* протестувати idempotency;
* протестувати `X-Request-Id`;
* протестувати `429 + Retry-After`;
* протестувати timeout/retry;
* протестувати degraded mode;
* додати test data;
* перевірити відповідність реалізації OpenAPI;
* перевірити DTO та ErrorResponse;
* провести ручне end-to-end тестування:

  * register;
  * login;
  * create event;
  * join event;
  * open chat;
  * send message;
  * map.

**DoD:**

* критичні backend use cases покриті тестами;
* integration tests проходять;
* resilience-сценарії перевірені;
* основний user flow проходить end-to-end;
* OpenAPI відповідає реалізації;
* знайдені критичні помилки виправлені.

---

## WEEK 8

### Docker & CI/CD

#### Docker

* створити Dockerfile для API;
* створити Dockerfile для Flutter Web;
* додати `.dockerignore`;
* створити `docker-compose.yml`;
* додати сервіси:

  * `frontend`;
  * `api`;
  * `db`;
* налаштувати environment variables;
* винести секрети з коду;
* перевірити запуск з чистого середовища;
* додати команди до README:

  * `docker compose up -d`;
  * `docker compose down`;
* перевірити API через HTTP-запит після запуску.

#### CI

* створити GitHub Actions workflow;
* triggers:

  * `push`;
  * `pull_request`;
* додати:

  * checkout;
  * встановлення залежностей;
  * dependency cache;
  * build;
  * tests;
  * lint, якщо застосовується;
* завантажувати coverage/JUnit artifacts за наявності;
* додати CI badge у README;
* заборонити merge без успішного CI через required checks.

#### Delivery

* реалізувати delivery для **всіх сервісів, які реально збираються**:

  * API image;
  * Flutter Web image;
* публікувати images у GHCR;
* використовувати теги:

  * `vX.Y.Z`;
  * `sha-<commit>`;
* налаштувати мінімальні GitHub permissions;
* додати `concurrency`;
* використати `cancel-in-progress`;
* обмежити `timeout-minutes`;
* не запускати CD без потреби на кожен commit.

#### Style Points

Виконати щонайменше **2**:

* semantic tagging;
* automatic draft release notes;
* reusable workflow / composite action;
* Job Summary з coverage та artifacts/packages;
* Dependabot;
* посилені permissions + concurrency;
* Trivy security scan з `exit-code: 0`.

**DoD:**

* `docker compose up -d` запускає `frontend + api + db`;
* система працює з чистого середовища;
* README містить повну інструкцію запуску;
* CI проходить на PR;
* tests виконуються в CI;
* API та frontend images публікуються у GHCR;
* images мають `vX.Y.Z` та `sha-*` tags;
* налаштовані permissions;
* налаштований concurrency;
* виконано щонайменше 2 Style Points.

---

## WEEK 9

### Observability & Kubernetes Architecture

#### Observability

* підняти observability stack:

  * Grafana;
  * OTEL Collector;
  * Loki;
  * Tempo;
  * Prometheus;
* підключити ASP.NET до OpenTelemetry;
* налаштувати OTLP;
* задати:

```text
service.name = zdybanka-api
```

* забезпечити щонайменше два типи telemetry:

  * traces;
  * metrics або logs;
* додати корисні attributes:

  * `http.route`;
  * `user_id`;
  * `event_id`;
  * інші релевантні атрибути;
* створити власний RED dashboard;
* додати мінімум 4 панелі:

  * requests/sec;
  * error rate;
  * p95 latency;
  * Loki logs;
* забезпечити спільний time range для панелей;
* експортувати dashboard у:

  * `docs/observability/red-dashboard.json`;
* описати PromQL/LogQL для панелей;
* описати використання dashboard у production;
* перевірити traces у Tempo;
* перевірити logs у Loki;
* описати підключення OTEL:

  * бібліотеки;
  * environment variables;
  * attributes;
  * приклади використання attributes у Grafana.

#### Grafana Alerts

Створити **мінімум 2 production-oriented alerts**:

1. **Error Rate**

   * 5xx rate > 5%;
   * evaluation window — наприклад, 5 хв.

2. **p95 Latency**

   * p95 latency > визначеного порогу;
   * evaluation window — наприклад, 5 хв.

Для кожного:

* PromQL query;
* threshold;
* evaluation window;
* contact point;
* notification policy;
* перевірка стану `Evaluating`;
* Alert list на dashboard;
* короткий runbook:

  * що означає alert;
  * що перевірити;
  * що робити команді.

#### Kubernetes — теоретична схема

Створити `docs/kubernetes-architecture.png`:

```text
User / Client
      ↓
DNS
      ↓
Ingress / Gateway
      ↓
Kubernetes Cluster
      ↓
Namespace
      ↓
Service
      ↓
Deployment
      ↓
Pods
```

На схемі показати:

* домен;
* Host/Path routing;
* Namespace;
* Deployment;
* кількість replicas;
* image;
* Service;
* Service type;
* 2–3 Pod-и;
* зв'язок Service → Pods;
* Git;
* CI/CD;
* container registry.

**DoD:**

* ASP.NET відправляє telemetry;
* traces видно у Tempo;
* logs видно у Loki;
* metrics доступні у Prometheus;
* RED dashboard має 4 необхідні панелі;
* dashboard збережений у JSON;
* створено 2 робочі production-oriented alerts;
* для alerts налаштовані contact points та notification policies;
* є короткий runbook;
* Kubernetes theoretical diagram готова.

---

## WEEK 10

### Kubernetes Deployment & Final Stabilization

#### Kubernetes

* встановити/підготувати Minikube;
* встановити `kubectl`;
* створити Namespace;
* створити ConfigMap;
* створити Secret;
* створити Deployment для власного ASP.NET API;
* створити Service;
* створити Ingress;
* налаштувати власний домен, наприклад:

  * `api.zdybanka.local`;
* налаштувати routing через Ingress;
* розгорнути API у Minikube;
* перевірити через:

  * `kubectl port-forward`;
  * Ingress;
* перевірити:

  * `kubectl get`;
  * `kubectl describe`;
  * `kubectl logs`;
* продемонструвати зміну ConfigMap;
* виконати `rollout restart`;
* перевірити нову конфігурацію;
* додати liveness probe;
* додати readiness probe;
* перевірити їх через `kubectl describe`;
* видалити Pod;
* перевірити автоматичне створення нового Pod;
* перевірити базовий debug-flow:

  * Pod;
  * Service;
  * Ingress;
* перевірити власний API у Kubernetes.

#### Міграція власного сервісу

* використати саме власний ASP.NET API, а не `k8s-demo`;
* додати Docker image;
* створити власні:

  * Deployment;
  * Service;
  * ConfigMap;
  * Secret;
  * Ingress;
* перевірити endpoint API;
* описати у `REPORT.md`:

  * призначення сервісу;
  * основні endpoints;
  * Dockerfile;
  * Deployment;
  * Service;
  * ConfigMap/Secret;
  * відмінності від `k8s-demo`;
  * процес міграції в Kubernetes.

#### Finalization

* провести повне end-to-end тестування;
* перевірити:

  * authentication;
  * authorization;
  * CRUD events;
  * participation;
  * filtering;
  * map;
  * chat;
  * SignalR;
  * administration;
  * error handling;
  * resilience;
* перевірити Docker Compose;
* перевірити CI/CD;
* перевірити GHCR images;
* перевірити OpenTelemetry;
* перевірити Grafana dashboards;
* перевірити alerts;
* перевірити Kubernetes;
* виправити integration bugs;
* провести code cleanup;
* оновити README;
* оновити `business_doc.md` відповідно до фактично реалізованого функціоналу;
* оновити architecture diagram;
* завершити API documentation;
* завершити ADR;
* додати звіти/скріншоти для практичних робіт;
* створити фінальний release/tag.

**DoD:**

* власний ASP.NET API працює в Kubernetes;
* є Namespace, Deployment, Service, ConfigMap, Secret та Ingress;
* працюють liveness/readiness probes;
* Pod автоматично відновлюється після видалення;
* працює доступ через Ingress;
* ConfigMap/Secret перевірені;
* є `REPORT.md` із описом міграції власного сервісу;
* Docker Compose запускається з чистого середовища;
* CI/CD проходить;
* images доступні у GHCR;
* telemetry працює;
* RED dashboard працює;
* 2 production-oriented alerts працюють;
* основні сценарії працюють end-to-end;
* документація відповідає фактичному стану проєкту;
* створено фінальний release/tag.

---

## Загальна послідовність

```text
W1  Foundation / Business Documentation
 ↓
W2  DDD / Architecture / Backend / DB
 ↓
W3  OpenAPI / CRUD / API Contract
 ↓
W4  Auth / Users / Unit Tests
 ↓
W5  Events / Geo / Resilience
 ↓
W6  Map / SignalR / Chat / Administration
 ↓
W7  Testing / Integration / Quality
 ↓
W8  Docker / CI / CD / GHCR
 ↓
W9  Observability / Alerts / Kubernetes Architecture
 ↓
W10 Kubernetes / Integration / Final Release
```
