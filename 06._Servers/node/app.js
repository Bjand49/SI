import swaggerAutogen from 'swagger-autogen';

const outputFile = './swagger_output.json'
const endpointsFiles = ['./routers/personRouter.js']

swaggerAutogen(outputFile, endpointsFiles)

const app = express();

app.get("/", (req,res)=>
{
    res.send({message:"try going to /monkeyland"});
});
app.get("/monkeyland", (req,res)=>
{
    res.send({message:"we monkey tonkey up in here"});
});

const options = {
  definition: {
    openapi: '3.0.0',
    info: {
      title: 'Hello World',
      version: '1.0.0',
    },
  },
  apis: ['.*.js'], // files containing annotations as above
};

const openapiSpecification = swaggerJsdoc(options);
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(openapiSpecification));

app.listen(8080);

